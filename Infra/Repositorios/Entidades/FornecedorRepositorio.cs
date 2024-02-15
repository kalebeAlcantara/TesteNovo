using Domain.Entities;
using Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Repositorios.Entidades
{
	public class FornecedorRepositorio : Repositorio<Fornecedor>
	{
		public FornecedorRepositorio(SQLContext context) : base(context)
		{ }

		public override Fornecedor GetById(int id)
		{
			var query = _context.Set<Fornecedor>().Where(e => e.Id == id);

			if (query.Any())
				return query.First();

			return null;
		}

		public override IEnumerable<Fornecedor> GetAll()
		{
			var query = _context.Set<Fornecedor>().Where(x => x.Ativo);

			return query.Any() ? query.ToList() : new List<Fornecedor>();
		}
		public override IEnumerable<Fornecedor> GetProc(string procedure, string concatedParams)
		{
			return _context.Fornecedor.FromSqlInterpolated($"{procedure} {concatedParams}").ToList();
		}
		
	}
}
