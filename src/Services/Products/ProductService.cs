
using Domain.Products;
using Shared.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Products
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> products = new();

        static ProductService()
        {
            var productFaker = new ProductFaker();
            products = productFaker.Generate(50);
        }


        public async Task<ProductResponse.GetIndex> GetIndexAsync(ProductRequest.GetIndex request)
        {
            await Task.Delay(100);

            ProductResponse.GetIndex response = new();
            var query = products.AsQueryable();

            response.TotalAmount = query.Count();

            query = query.Skip(request.Amount * request.Page);
            query = query.Take(request.Amount);
            query.OrderBy(x => x.Name);
            response.Products = products.Select(x => new ProductDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Width = x.Width,
                Height = x.Height,
                Depth = x.Depth,
                Category = x.Category.Name,
                
            }).ToList();
            
            return response;
        }
    }
}
