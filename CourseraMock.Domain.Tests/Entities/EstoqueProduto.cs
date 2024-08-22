using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseraMock.Domain.Tests.Interfaces;

namespace CourseraMock.Domain.Tests.Entities
{
    public class EstoqueProduto : IObservavel
    {
        private int _estoqueProduto;

        public void Update(Produto produto)
        {
            RemoverProdutoEstoque(produto);
        }

        internal void AdicionarProdutoEstoque(Produto produto)
        {
            _estoqueProduto += produto.Quantidade;
        }

        internal int GetQuantidadeEstoque()
        {
            return _estoqueProduto;
        }

        internal void RemoverProdutoEstoque(Produto produto)
        {
            _estoqueProduto -= produto.Quantidade;
        }
    }
}