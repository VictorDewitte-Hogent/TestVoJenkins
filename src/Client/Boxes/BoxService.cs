using Shared.Boxes;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Extensions;

namespace Client.Boxes
{
    public class BoxService : IBoxService
    {
        private readonly HttpClient client;
        private const string endpoint = "api/box";
        public BoxService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<BoxResponse.Create> CreateAsync(BoxRequest.Create request)
        {
            var response = await client.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<BoxResponse.Create>();
        }

        public async Task<BoxResponse.GetIndex> GetIndexAsync(BoxRequest.GetIndex request)
        {
            var queryParameters = request.GetQueryString();
            var response = await client.GetFromJsonAsync<BoxResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }

        public async Task<BoxResponse.GetDetail> GetDetailAsync(BoxRequest.GetDetail request)
        {
            var response = await client.GetFromJsonAsync<BoxResponse.GetDetail>($"{endpoint}/{request.BoxId}");
            return response;
        }

        public async Task DeleteAsync(BoxRequest.Delete request)
        {
            await client.DeleteAsync($"{endpoint}/{request.BoxId}");
        }

        public async Task<BoxResponse.Edit> EditAsync(BoxRequest.Edit request)
        {
            var response = await client.PutAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<BoxResponse.Edit>();
        }
    }
}
