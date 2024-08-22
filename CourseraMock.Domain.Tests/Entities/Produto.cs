using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseraMock.Domain.Tests.Entities
{
    public class Produto
    {
        private int _valor;
        private int _quantidade;
        public int Valor { get => _valor; }
        public int Quantidade { get => _quantidade; }

        public Produto(int valor, int quantidade)
        {
            _valor = valor;
            _quantidade = quantidade;
        }
    }
}