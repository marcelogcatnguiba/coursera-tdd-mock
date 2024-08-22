using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseraMock.Domain.Tests.Interfaces;
using Moq;

namespace CourseraMock.Domain.Tests.Entities
{
    public class CarrinhoCompra : ISujeito
    {
        private ICollection<Produto> _listaProduto = new List<Produto>();
        private ICollection<IObservavel> _listaObservaveis = new List<IObservavel>();

        public bool AdicionarObservavel(IObservavel observavel)
        {
            try
            {
                _listaObservaveis.Add(observavel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Notificar(Produto produto)
        {
            foreach (var ob in _listaObservaveis)
                ob.Update(produto);
        }

        public bool RemoverObservavel(IObservavel observavel)
        {
            throw new NotImplementedException();
        }

        internal bool AdicionaProduto(Produto produto)
        {

            try
            {
                _listaProduto.Add(produto);
                Notificar(produto);
                return true;
            }
            catch
            {
                return false;
            }

        }

        internal int GetValorTotalProdutos()
        {
            var valorTotal = 0;
            foreach (var p in _listaProduto)
                valorTotal += p.Valor * p.Quantidade;

            return valorTotal;
        }

        public bool ContainObservaveis()
        {
            return _listaObservaveis.Any();
        }
    }
}