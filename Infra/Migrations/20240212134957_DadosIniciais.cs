using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class DadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "varchar(15)", nullable: false),
                    Razao_Social = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "Boolean", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "Int32", nullable: false),
                    Nome = table.Column<string>(type: "varchar(500)", nullable: false),
                    Medida = table.Column<string>(type: "varchar(8)", nullable: false),
                    Ativo = table.Column<bool>(type: "Bit", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Tipo = table.Column<int>(type: "Int32", nullable: false),
                    Fornecedor_Id = table.Column<int>(type: "int", nullable: false),
                    Material_Id = table.Column<int>(type: "int", nullable: false),
                    Qtd = table.Column<decimal>(type: "Decimal(18,0)", nullable: false),
                    Valor_Unitario = table.Column<decimal>(type: "Decimal(18,0)", nullable: false),
                    Valor_Total = table.Column<decimal>(type: "Decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Fornecedor_FornecedorId",
                        column: x => x.Fornecedor_Id,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Material_MaterialId",
                        column: x => x.Material_Id,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_FornecedorId",
                table: "Movimentacao",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_MaterialId",
                table: "Movimentacao",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
