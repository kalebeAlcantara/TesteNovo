using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Fornecedor : BaseEntity
    {
        public Fornecedor() { }
        public Fornecedor(string cnpj, string razaoSocial) 
        { 
            this.CNPJ = cnpj;
            this.RazaoSocial = razaoSocial;
        }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

		public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

		public void Update(string cnpj, string razaoSocial, bool ativo)
        {
            this.CNPJ = cnpj;
            this.RazaoSocial = razaoSocial;
            this.Ativo = ativo;
        }
		public void Delete()
		{
			this.Ativo = false;
		}
	}
}
