using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Web.Models
{
	public class MovimentacaoViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Preencha a data da movimentação.")]
		public DateTime Data { get; set; }

		[Required(ErrorMessage = "Preencha o tipo da movimentação.")]
		public ETipoMovimentacao Tipo { get; set; }


		[Required(ErrorMessage = "Selecione o Fornecedor.")]
		public string FornecedorNome { get; set; }
		public int FornecedorId { get; set; }


		[Required(ErrorMessage = "Selecione o Material.")]
		public string MaterialNome { get; set; }
		public int MaterialId { get; set; }

		[Required(ErrorMessage = "Informe a Quantidade.")]
		public Decimal Quantidade { get; set; }

		[Required(ErrorMessage = "Informe o valor unitário.")]
		public Decimal ValorUnitario { get; set; }

		[Required(ErrorMessage = "Informe o valor total.")]
		public Decimal ValorTotal { get; set; }

		public List<Movimentacao> Cadastrados { get; set; }
	}
}
