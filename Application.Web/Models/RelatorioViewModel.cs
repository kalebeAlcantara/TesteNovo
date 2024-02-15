using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Application.Web.Models
{
	public class RelatorioViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Preencha a data da movimentação.")]
		public DateTime DataDe { get; set; }
		[Required(ErrorMessage = "Preencha a data da movimentação.")]
		public DateTime DataAte { get; set; }

		[Required(ErrorMessage = "Tipo de movimentação é obrigatorio.")]
		public ETipoMovimentacao TipoMovimentacao { get; set; }

		[Required(ErrorMessage = "Fornecedor é obrigatorio.")]
		public string FornecedorNome { get; set; }
		public int FornecedorId { get; set; }

		public int? MaterialId { get; set; }

		public string? MaterialNome { get; set; }

		public List<DadosRelatorio> Relatorio { get; set; }
	}
	public class DadosRelatorio
	{
		public string MaterialCodigo { get; set; }
		public List<Items> MovimentacoesMaterial { get; set; }
		public decimal QtdTotalEntrada { get; set; }
		public decimal ValorTotalEntrada { get; set; }

		public decimal QtdTotalSaida { get; set; }
		public decimal ValorTotalSaida { get; set; }

		public decimal QtdTotaldSaldo { get; set; }
		public decimal ValorTotalSaldo { get; set; }

	}
	public class Items
	{
		public string MaterialCodigo { get; set; }
		public DateTime Data { get; set; }
		public decimal QtdEntrada { get; set; }
		public decimal ValorEntrada { get; set; }

		public decimal QtdSaida { get; set; }
		public decimal ValorSaida { get; set; }

		public decimal QtdSaldo { get; set; }
		public decimal ValorSaldo { get; set; }
	}
}

