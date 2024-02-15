using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Entidades;

namespace Domain.Repositorios.Entidades
{
	public class FornecedorServico : IFornecedorServico
	{
		private readonly IRepositorio<Fornecedor> _FornecedorRepository;
		public FornecedorServico(IRepositorio<Fornecedor> fornecedorRepository)
		{
			_FornecedorRepository = fornecedorRepository;
		}
		public void Save(int id, string cnpj, string razaoSocial, bool ativo)
		{
			var fornec = _FornecedorRepository.GetById(id);
			if (id == 0 || fornec == null)
			{
				fornec = new Fornecedor(cnpj, razaoSocial);
				fornec.DataCadastro = DateTime.Now;
				fornec.Ativo = ativo;
				_FornecedorRepository.Save(fornec);
			}
			else
			{
				if (ativo)
					fornec.Update(cnpj, razaoSocial, ativo);
				else
					fornec.Delete();

				_FornecedorRepository.Update(fornec);
			}
		}

		public IEnumerable<Fornecedor> GetAll()
		{
			var fornec = _FornecedorRepository.GetAll();
			return fornec;
		}
		public Fornecedor GetById(int id)
		{
			var fornec = _FornecedorRepository.GetById(id);
			return fornec;
		}
		public IEnumerable<Fornecedor> GetProc(string procedure, string concatedParams)
		{
			var fornec = _FornecedorRepository.GetProc(procedure, concatedParams);
			return fornec;
		}
	}
}
