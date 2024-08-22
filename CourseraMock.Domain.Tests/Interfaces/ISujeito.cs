using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseraMock.Domain.Tests.Entities;

namespace CourseraMock.Domain.Tests.Interfaces
{
    public interface ISujeito
    {
        public bool AdicionarObservavel(IObservavel observavel);
        public bool RemoverObservavel(IObservavel observavel);
        public void Notificar(Produto produto);
    }
}