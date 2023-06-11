﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VouViajar.Excursoes.Infrastructure.Persistence;

#nullable disable

namespace VouViajar.Excursoes.Migrations
{
    [DbContext(typeof(ExcursaoDbContext))]
    partial class ExcursaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Excursoes")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VouViajar.Excursoes.Domain.Entities.Aggregates.Excursao", b =>
                {
                    b.Property<int>("ExcursaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExcursaoID"));

                    b.Property<int>("AgenciaID")
                        .HasColumnType("int");

                    b.Property<string>("Arquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CadastradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinoID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrigemID")
                        .HasColumnType("int");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SituacaoID")
                        .HasColumnType("int");

                    b.Property<int>("TipoID")
                        .HasColumnType("int");

                    b.Property<int>("TotalVagas")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorVaga")
                        .HasPrecision(5)
                        .HasColumnType("decimal");

                    b.HasKey("ExcursaoID");

                    b.HasIndex("DestinoID")
                        .IsUnique();

                    b.HasIndex("OrigemID")
                        .IsUnique();

                    b.HasIndex("SituacaoID")
                        .IsUnique();

                    b.HasIndex("TipoID")
                        .IsUnique();

                    b.ToTable("Excursao", "Excursoes");
                });

            modelBuilder.Entity("VouViajar.Excursoes.Domain.Entities.Localidade", b =>
                {
                    b.Property<int>("LocalidadeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalidadeID"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocalidadeID");

                    b.ToTable("Localidade", "Excursoes");
                });

            modelBuilder.Entity("VouViajar.Excursoes.Domain.Entities.Situacao", b =>
                {
                    b.Property<int>("SituacaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SituacaoID"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SituacaoID");

                    b.ToTable("Situacao", "Excursoes");
                });

            modelBuilder.Entity("VouViajar.Excursoes.Domain.Entities.Tipo", b =>
                {
                    b.Property<int>("TipoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoID"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoID");

                    b.ToTable("Tipo", "Excursoes");
                });

            modelBuilder.Entity("VouViajar.Excursoes.Domain.Entities.Aggregates.Excursao", b =>
                {
                    b.HasOne("VouViajar.Excursoes.Domain.Entities.Localidade", "Destino")
                        .WithOne()
                        .HasForeignKey("VouViajar.Excursoes.Domain.Entities.Aggregates.Excursao", "DestinoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VouViajar.Excursoes.Domain.Entities.Localidade", "Origem")
                        .WithOne()
                        .HasForeignKey("VouViajar.Excursoes.Domain.Entities.Aggregates.Excursao", "OrigemID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VouViajar.Excursoes.Domain.Entities.Situacao", "Situacao")
                        .WithOne()
                        .HasForeignKey("VouViajar.Excursoes.Domain.Entities.Aggregates.Excursao", "SituacaoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VouViajar.Excursoes.Domain.Entities.Tipo", "Tipo")
                        .WithOne()
                        .HasForeignKey("VouViajar.Excursoes.Domain.Entities.Aggregates.Excursao", "TipoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Origem");

                    b.Navigation("Situacao");

                    b.Navigation("Tipo");
                });
#pragma warning restore 612, 618
        }
    }
}
