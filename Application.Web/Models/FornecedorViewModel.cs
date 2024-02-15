using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Web.Models
{
	public class FornecedorViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Preencha o CNPJ.")]
		[MaxLength(15, ErrorMessage = "O CNPJ pode ter no máximo 15 caracteres.")]
		[DataType(DataType.Text)]
		[RegularExpression("[0-9]+", ErrorMessage = "Informe somente números")]
		public string CNPJ { get; set; }

		[Required(ErrorMessage = "Preencha a razão social")]
		[MaxLength(100, ErrorMessage = "A razão social pode ter no máximo 100 caracteres.")]
		public string RazaoSocial { get; set; }
		public List<Fornecedor> Cadastrados { get; set; }

	}
}
