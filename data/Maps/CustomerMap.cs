using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerManagement.Models;

namespace CustomerManagement.Data.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CNPJ)
            .IsRequired()
            .HasMaxLength(14)
            .HasColumnType("varchar(14)");

            builder.Property(x => x.RazaoSocial)
            .IsRequired()
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");

            builder.Property(x => x.NomeFantasia)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");

            builder.Property(x => x.Email)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");

            builder.Property(x => x.Telefone)
            .HasMaxLength(11)
            .HasColumnType("varchar(11)");

            builder.Property(x => x.NomeContato)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");

            builder.Property(x => x.EnderecoCep)
            .HasMaxLength(9)
            .HasColumnType("varchar(9)");

            builder.Property(x => x.EnderecoLogradouro)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");

            builder.Property(x => x.EnderecoNro)
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

            builder.Property(x => x.EnderecoBairro)
            .HasMaxLength(60)
            .HasColumnType("varchar(60)");

            builder.Property(x => x.EnderecoCidade)
            .HasMaxLength(60)
            .HasColumnType("varchar(60)");

            builder.Property(x => x.EnderecoEstado)
            .HasMaxLength(60)
            .HasColumnType("varchar(60)");

        }
    }
}