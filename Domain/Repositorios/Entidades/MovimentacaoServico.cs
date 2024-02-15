using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Entidades;
using System.Runtime.InteropServices.Marshalling;

namespace Domain.Repositorios.Entidades
{
	public class MovimentacaoServico : IMovimentacaoServico
	{
		private readonly IRepositorio<Movimentacao> _MovimentacaoRepository;
		private readonly IRepositorio<Movimentacao> _RelatorioRepository;
		public MovimentacaoServico(IRepositorio<Movimentacao> movimentacaoRepository, IRepositorio<Movimentacao> relatorioRepository)
		{
			_MovimentacaoRepository = movimentacaoRepository;
			_RelatorioRepository = relatorioRepository;
		}

		public void Save(int id, DateTime data, int tipo, int fornecedor, int material, decimal quantidade, decimal valorUn, decimal valorTotal)
		{
			var par = new Dictionary<string, object> {
						  { "@Id", id },
						  { "@Data", data } ,
						  { "@Tipo", tipo },
						  { "@Fornecedor", fornecedor },
						  { "@Material", Convert.ToString(material) },
						  { "@QTD", quantidade },
						  { "@VALOR_UN", valorUn },
						  { "@VALOR_TOTAL", valorTotal }
				};

			if (id == 0)
			{
				par.Remove("@Id");
				var variaveis = string.Join(", ", par.Select(x => x.Key).ToList());
				_MovimentacaoRepository.ExecProc("dbo.InserirMovimentacoes", variaveis, par);
			}
			else
			{
				var variaveis = string.Join(", ", par.Select(x => x.Key).ToList());
				_MovimentacaoRepository.ExecProc("AtualizarMovimentacoes", variaveis, par);
			}
		}
		public void Delete(int id)
		{
			var par = new Dictionary<string, object> { { "@Id", id } };
			_MovimentacaoRepository.ExecProc("dbo.DeletarMovimentacoes", "@Id", par);
		}
		public IEnumerable<Movimentacao> GetAll()
		{
			return _MovimentacaoRepository.GetAll();
		}
		public Movimentacao GetById(int id)
		{
			return _MovimentacaoRepository.GetById(id);
		}
		public IEnumerable<Movimentacao> GetProc(string procedure, string concatedParams)
		{
			var dados = _RelatorioRepository.GetProc(procedure, concatedParams);
			return dados;
		}
	}
}
