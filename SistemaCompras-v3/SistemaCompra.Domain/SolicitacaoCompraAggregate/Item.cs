using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Item : Entity
    {
        public Produto Produto { get; set; }
        public int Qtde { get; set; }
        public SolicitacaoCompra SolicitacaoCompra { get; set; }

        public Money Subtotal => ObterSubtotal();

        public Item(Produto produto, int qtde, SolicitacaoCompra solicitacao)
        {
            Id = Guid.NewGuid();
            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            Qtde = qtde;
            this.SolicitacaoCompra = solicitacao;
        }

        private Money ObterSubtotal()
        {
            return new Money(Produto.Preco.Value * Qtde);
        }

        private Item() { }

    }
}
