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
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESA");

            builder.HasKey(e => e.IdEmpresa);

            builder.Property(e => e.IdEmpresa)
                .HasColumnName("ID_EMPRESA")
                .IsRequired();

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(e => e.RazaoSocial)
                .IsUnique();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(14)
                .IsRequired();

            builder.HasIndex(c => c.Cnpj)
                .IsUnique();

            builder.Property(c => c.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();


        }
    }
}
