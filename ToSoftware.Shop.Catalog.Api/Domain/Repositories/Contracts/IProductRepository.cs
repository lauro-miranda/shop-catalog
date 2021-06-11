using LM.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSoftware.Shop.Catalog.Api.Domain.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Maybe<Product>> FindAsync(Guid code);

        Task<List<Product>> FindAsync(List<Guid> codes);
    }
}