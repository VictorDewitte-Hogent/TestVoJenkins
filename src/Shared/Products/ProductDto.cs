using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Products
{
    public static class ProductDto
    {
       public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }
            public float Depth { get; set; }
            public string Category { get; set; }
        }

 


    }
}
