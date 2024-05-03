using EmpresaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO");

            builder.HasKey(f => f.IdFuncionario);

            builder.Property(f => f.IdFuncionario)
                .HasColumnName("ID_FUNCIONARIO")
                .IsRequired();

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(6)
                .IsRequired();

            builder.HasIndex(f => f.Matricula)
                .IsUnique();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(f => f.Cpf)
                .IsUnique();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .IsRequired();

            builder.Property(f => f.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("ID_EMPRESA")
                .IsRequired();

            #region Relacionamentos

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(f => f.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

        }
    }
}
