using LM.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToSoftware.Shop.Catalog.Api.Domain;
using ToSoftware.Shop.Catalog.Api.Domain.Repositories.Contracts;

namespace ToSoftware.Shop.Catalog.Api.Data
{
    public class ProductRepository : IProductRepository
    {
        public async Task<List<Product>> GetAllAsync() 
            => await Task.Run(() => GetAll());

        public async Task<Maybe<Product>> FindAsync(Guid code)
            => await Task.Run(() => GetAll().FirstOrDefault(p => p.Code.Equals(code)));

        static List<Product> GetAll() => new List<Product>
        {
            new Product(Guid.Parse("0828DB59-BF7A-4210-8DDB-56925BB1685B"), "Moto G6 Plus", 2347.99M),
            new Product(Guid.Parse("7D0733ED-634F-42E6-B2FC-710292C8AA8B"), "J5 Pro", 999.99M),
            new Product(Guid.Parse("1E7D15CF-FBD2-4DBA-9F59-ABD79F7DA32D"), "Moto X4", 1499.33M),
            new Product(Guid.Parse("C22181DF-B7B3-42A3-B159-BCE1BC5C0D73"), "Lg Q6", 3400.99M),
            new Product(Guid.Parse("74564268-6CAA-42A2-B9DE-36E548170F97"), "Moto G5s", 2344.89M),
            new Product(Guid.Parse("837C2C4E-5CD9-4D58-9BDB-A9417ECA10BE"), "J7 Pro", 1199.99M),
            new Product(Guid.Parse("151B6CC0-A582-4407-9314-10E2E5D6618C"), "Asus Zenfone", 1999.99M),
            new Product(Guid.Parse("B97DFCF9-443C-4C45-8EF5-9AF1045B2E05"), "Moto G6", 3398.99M),
            new Product(Guid.Parse("CC9435BB-678A-4BF9-8493-4D66057948FB"), "Galaxy S9", 4500.99M),
            new Product(Guid.Parse("43FE01FC-1CDA-4346-89DC-AEAF3AB6F66A"), "Iphone 8 Plus", 5999.99M)
        };

        public async Task<List<Product>> FindAsync(List<Guid> codes)
            => await Task.Run(() => GetAll().Where(p => codes.Contains(p.Code)).ToList());
    }
}