using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Orders
{
    public static class OrderRequest
    {
        public class GetIndex
        {
            public int CustomerId { get; set; }
            public int Page { get; set; }
            public int Amount { get; set; } = 25;
        }

        public class GetDetail
        {
            public int OrderId { get; set; }
        }

        public class Delete
        {
            public int OrderId { get; set; }
        }

        public class Create
        {
            public OrderDto.Mutate Order { get; set; }
        }

        public class Edit
        {
            public int OrderId { get; set; }
            public OrderDto.Mutate Order { get; set; }
        }
    }
}
