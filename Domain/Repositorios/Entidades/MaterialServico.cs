using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Entidades;

namespace Domain.Repositorios.Entidades
{
	public class MaterialServico : IMaterialServico
	{
		private readonly IRepositorio<Material> _MaterialRepository;
		public MaterialServico(IRepositorio<Material> MaterialRepository)
		{
			_MaterialRepository = MaterialRepository;
		}
		public void Save(int id, string codigo, string nome, string uniMedida, bool ativo)
		{
			var mat = _MaterialRepository.GetById(id);
			if (id == 0 || mat == null)
			{
				mat = new Material(codigo, nome, uniMedida);
				mat.DataCadastro = DateTime.Now;
				mat.Ativo = ativo;
				_MaterialRepository.Save(mat);
			}
			else
			{
				if (ativo)
					mat.Update(codigo, nome, uniMedida, ativo);
				else
					mat.Delete();

				_MaterialRepository.Update(mat);
			}
		}

		public IEnumerable<Material> GetAll()
		{
			var fornec = _MaterialRepository.GetAll();
			return fornec;
		}
		public Material GetById(int id)
		{
			var fornec = _MaterialRepository.GetById(id);
			return fornec;
		}
		public IEnumerable<Material> GetProc(string procedure, string concatedParams)
		{
			var fornec = _MaterialRepository.GetProc(procedure, concatedParams);
			return fornec;
		}
	}
}
