using LM.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSoftware.Shop.Catalog.Api.Domain.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<Response<List<Product>>> GetAllAsync();

        Task<Response<Product>> FindAsync(Guid code);
    }
}