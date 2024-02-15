using Domain.Entities;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext()
        {
        }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Material> Materiais { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Material>(new MaterialMap().Configure);
            modelBuilder.Entity<Fornecedor>(new FornecedorMap().Configure);
            modelBuilder.Entity<Movimentacao>(new MovimentacaoMap().Configure);
        }
    }
}
