using Domain.Entities;

namespace Domain.Interfaces.Entidades
{
	public interface IMovimentacaoServico
	{
		void Save(int id, DateTime data, int tipo, int fornecedor, int material, decimal quantidade, decimal valorUn, decimal valorTotal);
		void Delete(int id);
		IEnumerable<Movimentacao> GetAll();
		Movimentacao GetById(int id);
		IEnumerable<Movimentacao> GetProc(string procedure, string concatedParams);
	}
}
