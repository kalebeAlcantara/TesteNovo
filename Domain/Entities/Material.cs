using System;

namespace Domain.Entities
{
	public class Material : BaseEntity
	{
		public Material() { }

		public Material(string codigo, string nome, string uniMedida)
		{
			this.Codigo = codigo;
			this.Nome = nome;
			this.UnidadeMedida = uniMedida;
		}
		public string Codigo { get; set; }
		public string Nome { get; set; }
		public string UnidadeMedida { get; set; }
		public bool Ativo { get; set; }
		public DateTime DataCadastro { get; set; }
		public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

		public void Update(string codigo, string nome, string uniMedida, bool ativo)
		{
			this.Codigo = codigo;
			this.Nome = nome;
			this.UnidadeMedida = uniMedida;
			this.Ativo = ativo;
		}

		public void Delete()
		{
			this.Ativo = false;
		}
	}
}
