using LM.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToSoftware.Shop.Catalog.Api.Controllers.Mappers;
using ToSoftware.Shop.Catalog.Api.Domain.Repositories.Contracts;
using ToSoftware.Shop.Catalog.Api.Filters;
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

                if (!products.Any())
                    return response;

                return response.SetValue(products.ToResponseMessage());
            });

        [HttpGet, Route("{code}")]
        public async Task<IActionResult> GetAllAsync(Guid code)
            => await WithResponseAsync(async () =>
            {
                var response = Response<ProductResponseMessage>.Create();

                var product = await ProductRepository.FindAsync(code);

                if (!product.HasValue)
                    return response;

                return response.SetValue(product.Value.ToResponseMessage());
            });

        [HttpGet, ServiceFilter(typeof(CodeQueryFilter)), Route("s/{codes}")]
        public async Task<IActionResult> GetAllAsync([FromQuery] List<Guid> codes)
            => await WithResponseAsync(async () =>
            {
                var response = Response<List<ProductResponseMessage>>.Create();

                var products = await ProductRepository.FindAsync(codes);

                if (!products.Any())
                    return response;

                return response.SetValue(products.ToResponseMessage());
            });
    }
}