using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseraMock.Domain.Tests.Entities;

namespace CourseraMock.Domain.Tests.Interfaces
{
    public interface IObservavel
    {
        public void Update(Produto produto);
    }
}