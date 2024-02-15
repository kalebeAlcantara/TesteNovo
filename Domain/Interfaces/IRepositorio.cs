using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetProc(string procedure, string concatedParams);
		void ExecProc(string procedure, string variaveisSP, Dictionary<string, object> parameters);
		void Save(TEntity entity);
		void Update(TEntity entity);
	}
}