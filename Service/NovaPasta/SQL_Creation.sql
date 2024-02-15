CREATE TABLE Material (
    Id int identity,
    Codigo varchar(15) not null,
    Nome varchar(100) not null,
	Medida varchar(8) not null,
	Ativo bit default(1) not null,
    Data_Cadastro Datetime not null,
	PRIMARY KEY (Id)
);
CREATE TABLE Fornecedor (
    Id int identity,
    CNPJ varchar(15) not null,
    Razao_Social varchar(100) not null,
	Ativo bit default(1) not null,
	Data_Cadastro Datetime not null,
	PRIMARY KEY (Id)
);

CREATE TABLE Movimentacao (
	Id int identity,
    Data Datetime not null,
	Tipo int not null,
    Fornecedor_Id int not null,
	Material_Id int not null,
	Quantidade Decimal(8,2) not null,
	Valor_Unitario Decimal(8,2) not null,
	Valor_Total Decimal(8,2) not null,
	PRIMARY KEY (Id),
	CONSTRAINT FK_Movimentacao_Fornecedor FOREIGN KEY (Fornecedor_Id)
    REFERENCES Fornecedor(Id),
	CONSTRAINT FK_Movimentacao_Material FOREIGN KEY (Material_Id)
    REFERENCES Material(Id)
);


CREATE INDEX idx_Fornecedor
ON Fornecedor (CNPJ, Razao_Social,Ativo,Data_Cadastro);

CREATE INDEX idx_Material
ON Material (Codigo, Nome, Ativo,Data_Cadastro);

CREATE INDEX idx_Movimentacao
ON Movimentacao (Data, Tipo,Fornecedor_Id,Material_Id,Quantidade,Valor_Unitario,Valor_Total);
GO;

/* insert into Fornecedor
 values('073818578000123', 'Fornecedor 2', 1, GETDATE()),
 ('002750783000156', 'Fornecedor 3', 1, GETDATE()),
 ('238888783000133', 'Fornecedor 4', 0, GETDATE()),
 ('123456789000100', 'Fornecedor 5', 1, GETDATE());
 

insert into Material 
values ('10000A2','Material 1','Pça',1,getdate()),
('17000AH','Material 2','KG',1,getdate()),
('10000A4','Material 3','Saca',1,getdate()),
('10FG0A4','Material 4','Mg',1,getdate()),
('XM44','Material 5','Ton',1,getdate()),
('XM1556','Material 6','grains',0,getdate())*/

/*Id
Data
Tipo
Fornecedor_Id
Material_Id
Quantidade
Valor_Unitario
Valor_Total*/

CREATE PROCEDURE  InserirMovimentacoes
	   @Data            DATETIME     = NULL, 
	   @Tipo            INT          = NULL, 
       @Fornecedor      INT          = NULL, 
       @Material        INT          = NULL, 
       @QTD             DECIMAL      = NULL, 
       @VALOR_UN        DECIMAL      = NULL,
	   @VALOR_TOTAL     DECIMAL      = NULL
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO Movimentacao
          (Data
			,Tipo
			,Fornecedor_Id
			,Material_Id
			,Quantidade
			,Valor_Unitario
			,Valor_Total) 
     VALUES 
          ( 
            @Data,
            @Tipo,
            @Fornecedor,
            @Material,
			@QTD,
			@VALOR_UN,
			@VALOR_TOTAL
		) 
END 
GO


CREATE PROCEDURE  AtualizarMovimentacoes
       @Id              Int     = NULL, 
	   @Data            DATETIME     = NULL, 
	   @Tipo            INT          = NULL, 
       @Fornecedor      INT          = NULL, 
       @Material        INT          = NULL, 
       @QTD             DECIMAL      = NULL, 
       @VALOR_UN        DECIMAL      = NULL,
	   @VALOR_TOTAL     DECIMAL      = NULL
AS 
BEGIN 
     SET NOCOUNT ON 

     UPDATE Movimentacao SET 
             Data = @Data
			,Tipo = @Tipo
			,Fornecedor_Id = @Fornecedor
			,Material_Id = @Material
			,Quantidade = @QTD
			,Valor_Unitario = @VALOR_UN
			,Valor_Total = @VALOR_TOTAL
     WHERE Id = @Id
END 
GO

SELECT 
m.Codigo
,mt.Data
--entradas
,((select x.Quantidade,x.Valor_Total from Movimentacao x where Tipo = 1 FOR XML PATH('') )) AS ENTRADAS
,((select x.Quantidade,x.Valor_Total from Movimentacao x where Tipo = 2 FOR XML PATH('') )) AS SAIDAS
,((select x.Quantidade,x.Valor_Total from Movimentacao x where Tipo = 2 FOR XML PATH('') )) AS SALDO
,mt.Quantidade
FROM Movimentacao mt
join Material m on mt.Material_Id = m.Id

GO
CREATE PROCEDURE GerarRelatorio
       @DataDe            DATETIME     = NULL, 
	   @DataAte            DATETIME     = NULL, 
	   @Tipo            INT          = NULL, 
       @FornecedorId      INT          = NULL, 
       @MaterialId        INT          = NULL
	   AS 
BEGIN 
     SET NOCOUNT ON 
		SELECT 
		mt.Codigo
		,convert(varchar(55), m.Data, 103) as Data
		,(CASE WHEN m.Tipo = 1 THEN m.Valor_Total else 0 END) AS  ValorEntrada
		,(CASE WHEN m.Tipo = 1 THEN m.Quantidade else 0 END)  AS  QtdEntrada
		,(CASE WHEN m.Tipo = 2 THEN m.Valor_Total else 0 END) AS  ValorSaida
		,(CASE WHEN m.Tipo = 2 THEN m.Quantidade else 0 eND)  AS  QtdSaida
		
		FROM Movimentacao m
		JOIN Material mt on m.Material_Id = mt.Id
		JOIN Fornecedor f on m.Fornecedor_Id = f.Id
		where (@DataDe IS null OR m.Data >= @DataDe) AND
			  (@DataAte IS null OR m.Data <= @DataDe) AND
			  (@Tipo IS  NULL OR m.Tipo = @Tipo) AND
			  (@FornecedorId IS NULL OR f.Id = @FornecedorId) AND
			  (@MaterialId IS NULL OR mt.Id = @MaterialId)
	 END 
GO