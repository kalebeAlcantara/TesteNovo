using Domain.Entities;
using Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Repositorios.Entidades
{
	public class MovimentacaoRepositorio : Repositorio<Movimentacao>
	{
		public MovimentacaoRepositorio(SQLContext context) : base(context)
		{ }

		public override IEnumerable<Movimentacao> GetAll()
		{
			var query = _context.Set<Movimentacao>().Include(x => x.Fornecedor).Include(x => x.Material);

			return query.Any() ? query.ToList() : new List<Movimentacao>();
		}
		public override Movimentacao GetById(int id)
		{
			var query = _context.Set<Movimentacao>()
						.Include(x => x.Material)
						.Include(x => x.Fornecedor)
						.Where(e => e.Id == id);

			if (query.Any())
				return query.First();

			return null;
		}

		public override void ExecProc(string procedure, string variaveisSP, Dictionary<string, object> parameters)
		{
			List<SqlParameter> sqlParameters = new List<SqlParameter>();
			sqlParameters.AddRange(parameters.Select(x => new SqlParameter($"{x.Key}", x.Value)).ToArray());

			_context.Database.ExecuteSqlRaw(procedure + " " + variaveisSP, sqlParameters);
		}
	}
}
