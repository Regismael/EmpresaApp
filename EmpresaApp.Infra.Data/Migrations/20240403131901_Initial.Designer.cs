﻿// <auto-generated />
using System;
using EmpresaApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpresaApp.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240403131901_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmpresaApp.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid?>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_EMPRESA");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime?>("DataHoraCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORACADASTRO");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOMEFANTASIA");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("RAZAOSOCIAL");

                    b.HasKey("IdEmpresa");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.HasIndex("RazaoSocial")
                        .IsUnique();

                    b.ToTable("EMPRESA", (string)null);
                });

            modelBuilder.Entity("EmpresaApp.Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid?>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_FUNCIONARIO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime?>("DataAdmissao")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAADMISSAO");

                    b.Property<DateTime?>("DataHoraCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORACADASTRO");

                    b.Property<Guid?>("IdEmpresa")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_EMPRESA");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("MATRICULA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("IdEmpresa");

                    b.HasIndex("Matricula")
                        .IsUnique();

                    b.ToTable("FUNCIONARIO", (string)null);
                });

            modelBuilder.Entity("EmpresaApp.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("EmpresaApp.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionario")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EmpresaApp.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}