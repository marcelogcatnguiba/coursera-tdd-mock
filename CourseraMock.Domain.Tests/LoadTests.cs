using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseraMock.Domain.Tests.Entities;

namespace CourseraMock.Domain.Tests
{
    public abstract class LoadTests
    {
        public static Produto Produto { get; set; } = null!;

        public LoadTests()
        {
            Produto = new Produto(Faker.RandomNumber.Next(0, 100), Faker.RandomNumber.Next(0, 10));
        }


    }
}