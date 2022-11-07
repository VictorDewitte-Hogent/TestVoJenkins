using System.Collections.Generic;

namespace Shared.Orders
{
    public class OrderResponse
    {
        public class GetIndex
        {
            public List<OrderDto.Index> Orders { get; set; }
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public OrderDto.Detail Order { get; set; }
        }

        public class Delete
        {

        }

        public class Create
        {
            public int OrderId { get; set; }
        }

        public class Edit
        {
            public int OrderId { get; set; }
        }
    }
}
