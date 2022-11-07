using Shared.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Orders
{
    public static class OrderLineDto
    {
        public class Index
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public BoxDto.Index Box { get; set; }
            public int NrOfPallets { get; set; }
            public decimal Price { get; set; }
        }
    }
}
