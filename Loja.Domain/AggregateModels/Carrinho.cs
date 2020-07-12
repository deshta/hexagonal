using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.AggregateModels
{
    public class Carrinho
    {
        public decimal CarrinhoId { get; private set; }
        public Produto Produtos { get; private set; }

        public Carrinho(Produto produtos)
        {
            Produtos = produtos;
        }

        public void AtualizarProdutos(Produto produtos)
        {
            Produtos = produtos;
        }
    }
}
