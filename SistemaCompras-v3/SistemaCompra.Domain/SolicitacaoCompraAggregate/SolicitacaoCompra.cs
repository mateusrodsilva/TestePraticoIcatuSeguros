﻿using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            CondicaoPagamento = new CondicaoPagamento(0);
            Itens = new List<Item>();
        }

        public void AdicionarItem(Produto produto, int qtde, SolicitacaoCompra solicitacao)
        {
            Itens.Add(new Item(produto, qtde, solicitacao)); 
            
            TotalGeral = new Money((Itens.Select(x => x.Subtotal.Value).Sum()));
            

            if(TotalGeral.Value > 50000)
            {
                CondicaoPagamento = new CondicaoPagamento(30);
            }
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (itens.Count() <= 0) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));

        }
    }
}
