using Microsoft.EntityFrameworkCore;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            builder.Property(x => x.Id);
            builder.Property(x => x.TotalGeral)
            .HasColumnName("TotalGeral")
            .HasConversion(
                x => x.Value,
                x => new Money(x));

            builder.Property(x => x.NomeFornecedor)
            .HasColumnName("NomeFornecedor")
            .HasConversion(
                x => x.Nome,
                x => new NomeFornecedor(x));

            builder.Property(x => x.UsuarioSolicitante)
            .HasColumnName("UsuarioSolicitante")
            .HasConversion(
                x => x.Nome,
                x => new UsuarioSolicitante(x));

            builder.Property(x => x.CondicaoPagamento)
            .HasColumnName("CondicaoPagamento")
            .HasConversion(
                x => x.Valor,
                x => new CondicaoPagamento(x));
            

        }
    }
}
