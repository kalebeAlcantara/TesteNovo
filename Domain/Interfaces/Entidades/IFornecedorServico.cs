using Domain.Entities;

namespace Domain.Interfaces.Entidades
{
	public interface IFornecedorServico
	{
		void Save(int id, string cnpj, string razaoSocial, bool ativo);
		IEnumerable<Fornecedor> GetAll();
		Fornecedor GetById(int id);
		IEnumerable<Fornecedor> GetProc(string procedure, string concatedParams);
		
	}
}
