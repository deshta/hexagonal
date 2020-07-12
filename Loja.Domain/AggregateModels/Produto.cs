using Loja.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Loja.Domain.AggregateModels
{
    public class Produto
    {
        public decimal ProdutoId { get; set; }
        public string Descricao { get; private set; }
        public float Preco { get; private set; }
        public CodigoDeBarras CodigoDeBarras { get; private set; }

        public Produto(string descricao, float preco, CodigoDeBarras codigoDeBarras)
        {
            Descricao = descricao;
            Preco = preco;
            CodigoDeBarras = codigoDeBarras;
        }

        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void AtualizarDescricao(float preco)
        {
            Preco = preco;
        }

        public void AtualizarDescricao(CodigoDeBarras codigoDeBarras)
        {
            CodigoDeBarras = codigoDeBarras;
        }
    }
}
