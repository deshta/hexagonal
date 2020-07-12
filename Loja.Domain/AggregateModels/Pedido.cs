using Loja.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.AggregateModels
{
    public class Pedido
    {
        public decimal PedidoId { get; private set; }
        public Cliente Cliente { get; private set; }
        public Carrinho Carrinho { get; private set; }
        public DateTime DataPedido { get; private set; } = DateTime.Now;
        public Frete Frete { get; set; }
    }
}
