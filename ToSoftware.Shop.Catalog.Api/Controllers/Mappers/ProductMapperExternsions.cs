using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToSoftware.Shop.Catalog.Api.Domain;
using ToSoftware.Shop.Catalog.Api.Messages;

namespace ToSoftware.Shop.Catalog.Api.Controllers.Mappers
{
    public static class ProductMapperExternsions
    {
        public static ProductResponseMessage ToResponseMessage(this Product product)
        {
            if (product == null)
                return new ProductResponseMessage();

            return new ProductResponseMessage
            {
                Code = product.Code,
                Name = product.Name,
                Price = product.Price,
                FormattedPrice = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", product.Price).Replace(" ", "").Replace("R$", "R$ "),
                CreatedAt = product.CreatedAt
            };
        }

        public static List<ProductResponseMessage> ToResponseMessage(this List<Product> products)
        {
            if (products == null)
                return new List<ProductResponseMessage>();

            return products.Select(p => p.ToResponseMessage()).ToList();
        }
    }
}