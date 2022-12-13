using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoAgg.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoAgg.Produto> builder)
        {
            builder.ToTable("Produto");
            builder.Property(x => x.Preco)
            .HasColumnName("Preco")
            .HasConversion(
                x => x.Value,
                x => new Money(x))
            .HasColumnType("decimal(18,2)"); //Converasão adicionada para considerar o tipo Money como decimal
        }
    }
}
