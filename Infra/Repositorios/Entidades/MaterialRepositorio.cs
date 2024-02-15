using Domain.Entities;
using Infra.Context;

namespace Infra.Repositorios.Entidades
{
    public class MaterialRepositorio : Repositorio<Material>
    {
        public MaterialRepositorio(SQLContext context) : base(context)
        { }

        public override Material GetById(int id)
        {
            var query = _context.Set<Material>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Material> GetAll()
        {
            var query = _context.Set<Material>().Where(x => x.Ativo);

            return query.Any() ? query.ToList() : new List<Material>();
        }
    }
}
