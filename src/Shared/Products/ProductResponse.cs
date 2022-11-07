using Shared.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Products
{
    public static class ProductResponse
    {
        public class GetIndex
        {
            public List<ProductDto.Index> Products { get; set; } = new();
            public int TotalAmount { get; set; }
        }
    }
}
