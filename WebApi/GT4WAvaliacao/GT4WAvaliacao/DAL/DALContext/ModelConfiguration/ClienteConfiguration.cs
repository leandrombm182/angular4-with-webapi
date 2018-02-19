using GT4WAvaliacao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GT4WAvaliacao.DAL.DALContext.ModelConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("cliente");

            HasKey(c => c.Id);

            HasIndex(c => c.Cpf)
                .IsUnique();

            Property(c => c.Id)
                .HasColumnName("cod_cliente");

            Property(c => c.Nome)
                .HasColumnName("nome_cliente");

            Property(c => c.Cpf)
                .HasColumnName("num_cpf")
                .HasMaxLength(14);

            Property(c => c.DataNascimento)
                .HasColumnName("dat_nascimento")
                .HasColumnType("Date");

            Property(c => c.Peso)
                .HasColumnName("peso");

            Property(c => c.Estado)
                .HasMaxLength(2);

        }
    }
}