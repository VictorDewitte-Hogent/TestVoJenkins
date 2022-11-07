using Shared.Boxes;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Extensions;
using Shared.Products;

namespace Client.Products
{
    public class ProductService : IProductService
    {
        private readonly HttpClient client;
        private const string endpoint = "api/product";

        public ProductService(HttpClient client)
        {
            this.client = client;
        }


        public async Task<ProductResponse.GetIndex> GetIndexAsync(ProductRequest.GetIndex request)
        {

            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<ProductResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;

        }
    }
}