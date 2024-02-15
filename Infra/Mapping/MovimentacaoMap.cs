using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infra.Mapping
{
    internal class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("Movimentacao");

            //builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Data)
                .IsRequired()
                .HasColumnName("Data")
                .HasColumnType("DateTime");

            //builder.HasOne(p => p.Fornecedor)
            //builder.HasOne(p => p.Material);

            builder.HasOne(x => x.Fornecedor).WithMany(x => x.Movimentacoes).HasForeignKey("Fornecedor_Id");
			builder.HasOne(x => x.Material).WithMany(x => x.Movimentacoes).HasForeignKey("Material_Id");

			builder.Property(prop => prop.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade")
                .HasColumnType("Decimal(8,2)");

            builder.Property(prop => prop.ValorUnitario)
                .IsRequired()
                .HasColumnName("Valor_Unitario")
                .HasColumnType("Decimal(8,2)");

            builder.Property(prop => prop.ValorTotal)
                .IsRequired()
                .HasColumnName("Valor_Total")
                .HasColumnType("Decimal(8,2)");

            builder.Property(prop => prop.Tipo)
                .IsRequired()
                .HasColumnName("Tipo")
                .HasColumnType("Int32");
        }
    }
}
