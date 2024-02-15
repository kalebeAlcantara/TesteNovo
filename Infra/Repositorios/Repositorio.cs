using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.Data.SqlClient;
using System;

namespace Infra.Repositorios
{
	public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : BaseEntity
	{
		protected readonly SQLContext _context;
		public Repositorio(SQLContext context)
		{
			_context = context;
		}

		public virtual TEntity GetById(int id)
		{
			var query = _context.Set<TEntity>().Where(e => e.Id == id);
			if (query.Any())
				return query.FirstOrDefault();
			return null;
		}
		public virtual IEnumerable<TEntity> GetAll()
		{
			var query = _context.Set<TEntity>();
			if (query.Any())
				return query.ToList();
			return new List<TEntity>();
		}
		public virtual IEnumerable<TEntity> GetProc(string procedure, string concatedParams)
		{
			return new List<TEntity>();
		}

		public virtual void ExecProc(string procedure, string variaveisSP, Dictionary<string, object> parameters)
		{
		}
		public virtual void Save(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			_context.SaveChanges();

		}
		public virtual void Update(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			_context.SaveChanges();
		}
	}

}
