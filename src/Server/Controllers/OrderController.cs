using Microsoft.AspNetCore.Mvc;
using Shared.Boxes;
using Shared.Orders;
using System.Threading.Tasks;
namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public Task<OrderResponse.GetIndex> GetIndexAsync([FromQuery] OrderRequest.GetIndex request)
        {
            return orderService.GetIndexAsync(request);
        }

        [HttpGet("{OrderId}")]
        public Task<OrderResponse.GetDetail> GetDetailAsync([FromRoute] OrderRequest.GetDetail request)
        {
            return orderService.GetDetailAsync(request);
        }

        [HttpDelete("{OrderId}")]
        public Task DeleteAsync([FromRoute] OrderRequest.Delete request)
        {
            return orderService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<OrderResponse.Create> CreateAsync([FromBody] OrderRequest.Create request)
        {
            return orderService.CreateAsync(request);
        }

        [HttpPut]
        public Task<OrderResponse.Edit> EditAsync([FromBody] OrderRequest.Edit request)
        {
            return orderService.EditAsync(request);
        }
    }
}

