using Shared.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse.GetIndex> GetIndexAsync(OrderRequest.GetIndex request);
        Task<OrderResponse.GetDetail> GetDetailAsync(OrderRequest.GetDetail request);
        Task DeleteAsync(OrderRequest.Delete request);
        Task<OrderResponse.Create> CreateAsync(OrderRequest.Create request);
        Task<OrderResponse.Edit> EditAsync(OrderRequest.Edit request);
    }
}
