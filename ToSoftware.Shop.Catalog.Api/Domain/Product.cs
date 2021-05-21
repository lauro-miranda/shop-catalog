using LM.Domain.Entities;
using System;

namespace ToSoftware.Shop.Catalog.Api.Domain
{
    public class Product : Entity
    {
        [Obsolete(ConstructorObsoleteMessage, true)]
        Product() { }
        public Product(Guid code, string name, decimal price)
            : base(code)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
    }
}