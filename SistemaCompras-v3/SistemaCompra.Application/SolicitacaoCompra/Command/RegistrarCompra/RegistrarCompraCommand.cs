using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public List<ProdutosCompra> ProdutosCompra { get; set; }
    }

    public class ProdutosCompra //Classe criada para organizar produtos relacionados a Solicitação de Compra
    {
        public Guid IdProduto { get; set; }
        public int Qtde { get; set; }
    }
}
