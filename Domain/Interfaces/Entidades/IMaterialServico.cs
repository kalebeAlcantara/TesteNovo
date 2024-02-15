using Domain.Entities;

namespace Domain.Interfaces.Entidades
{
	public interface IMaterialServico
	{
		public void Save(int id, string codigo, string nome, string uniMedida, bool ativo);
		public IEnumerable<Material> GetAll();
		public Material GetById(int id);
		IEnumerable<Material> GetProc(string procedure, string concatedParams);
	}
}
