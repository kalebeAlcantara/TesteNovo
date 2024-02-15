using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    internal class MaterialMap : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Material");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Codigo)
                .IsRequired()
                .HasColumnName("Codigo")
                .HasColumnType("Int32");

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(500)");

            builder.Property(prop => prop.UnidadeMedida)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Medida")
               .HasColumnType("varchar(8)");

            builder.Property(prop => prop.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("Bit");

            builder.Property(prop => prop.DataCadastro)
               .IsRequired()
               .HasColumnName("Data_Cadastro")
               .HasColumnType("DateTime");
        }
    }
}
