﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(SQLContext))]
    partial class SQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Fornecedor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("Boolean")
                        .HasColumnName("Ativo");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DateTime")
                        .HasColumnName("Data_Cadastro");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Razao_Social");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Material", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("Boolean")
                        .HasColumnName("Ativo");

                    b.Property<int>("Codigo")
                        .HasColumnType("Int32")
                        .HasColumnName("Cod");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DateTime")
                        .HasColumnName("Data_Cadastro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Nome");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Unidade_Medida");

                    b.HasKey("Id");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Movimentacao", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValue(new DateTime(2024, 2, 12, 10, 49, 57, 106, DateTimeKind.Local).AddTicks(3462))
                        .HasColumnName("Data");

                    b.Property<int>("Fornecedor_Id")
                        .HasColumnType("int");

                    b.Property<int>("Material_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("Decimal")
                        .HasColumnName("Qtd");

                    b.Property<int>("Tipo")
                        .HasColumnType("Int32")
                        .HasColumnName("Tipo");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("Decimal")
                        .HasColumnName("Valor_Total");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("Decimal")
                        .HasColumnName("Valor_Unitario");

                    b.HasKey("Id");

                    b.HasIndex("Fornecedor_Id");

                    b.HasIndex("Material_Id");

                    b.ToTable("Movimentacao", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Movimentacao", b =>
                {
                    b.HasOne("Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("Fornecedor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Material_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Material");
                });
#pragma warning restore 612, 618
        }
    }
}
