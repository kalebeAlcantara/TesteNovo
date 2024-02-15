using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Movimentacao : BaseEntity
	{
		public Movimentacao() { }

		public Movimentacao(DateTime data, int tipo, int fornecedor, int material, decimal quantidade, decimal valorUn, decimal valorTotal)
		{
			this.Data = data;
			this.Tipo = (ETipoMovimentacao)tipo;
			this.Fornecedor = new Fornecedor() { Id = fornecedor, DataCadastro = DateTime.Today};
			this.Material = new Material() { Id = material, DataCadastro = DateTime.Today };
			this.Quantidade = quantidade;
			this.ValorUnitario = valorUn;
			this.ValorTotal = valorTotal;
		}

		public DateTime Data { get; set; }
		public ETipoMovimentacao Tipo { get; set; }
		public Fornecedor Fornecedor { get; set; }
		public Material Material { get; set; }
		public Decimal Quantidade { get; set; }
		public Decimal ValorUnitario { get; set; }
		public Decimal ValorTotal { get; set; }

		
		public void Update(DateTime data, int tipo, int fornecedor, int material, decimal quantidade, decimal valorUn, decimal valorTotal)
		{
			this.Data = data;
			this.Tipo = (ETipoMovimentacao)tipo;
			this.Fornecedor = new Fornecedor() { Id = fornecedor, DataCadastro = DateTime.Today };
			this.Material = new Material() { Id = material , DataCadastro = DateTime.Today };
			this.Quantidade = quantidade;
			this.ValorUnitario = valorUn;
			this.ValorTotal = valorTotal;
		}
		public void CalcularValorTotal()
		{
			this.ValorTotal = this.Quantidade * this.ValorUnitario;
		}
	}
}
