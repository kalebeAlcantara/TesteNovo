using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    internal class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CNPJ)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("CNPJ")
                .HasColumnType("varchar(15)");

			builder.Property(prop => prop.RazaoSocial)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Razao_Social")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("bit");

            builder.Property(prop => prop.DataCadastro)
             .IsRequired()
             .HasColumnName("Data_Cadastro")
             .HasColumnType("DateTime");
        }
    }
}
