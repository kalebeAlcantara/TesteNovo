using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Web.Models
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o código.")]
        [MaxLength(10, ErrorMessage = "O código pode ter no máximo 10 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha a unidade de medida.")]
        [MaxLength(8, ErrorMessage = "a Unidade de medida pode ter no máximo 8 caracteres.")]
        public string UnidadeMedida { get; set; }

        public bool? Ativo { get; set; }

        public List<Material> Cadastrados { get; set; }

	}
}
