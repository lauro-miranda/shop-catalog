using LM.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToSoftware.Shop.Catalog.Api.Controllers.Mappers;
using ToSoftware.Shop.Catalog.Api.Domain.Repositories.Contracts;
using ToSoftware.Shop.Catalog.Api.Messages;

namespace ToSoftware.Shop.Catalog.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProductController : Controller
    {
        IProductRepository ProductRepository { get; }

        public ProductController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAllAsync()
            => await WithResponseAsync(async () =>
            {
                var response = Response<IEnumerable<ProductResponseMessage>>.Create();

                var products = await ProductRepository.GetAllAsync();

                if (!products.Data.HasValue || !products.Data.Value.Any())
                    return response;

                return response.SetValue(products.Data.Value.ToResponseMessage());
            });

        [HttpGet, Route("{code}")]
        public async Task<IActionResult> GetAllAsync(Guid code)
            => await WithResponseAsync(async () =>
            {
                var response = Response<ProductResponseMessage>.Create();

                var product = await ProductRepository.FindAsync(code);

                if (!product.Data.HasValue)
                    return response;

                return response.SetValue(product.Data.Value.ToResponseMessage());
            });
    }
}