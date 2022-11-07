using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Packaging
{
    public class Box : Entity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public double Width { get; set; } 
        public double Height { get; set; }
        public double Length { get; set; }
        public decimal Price { get; set; }
        public Box(int customerid, string name, double width, double height, double length)
        {
            CustomerId = customerid;
            Name = name;
            Width = width;
            Height = height;
            Length = length;
            Price = (decimal) (Width * Height * Length);
        }
        public Box(int customerid, string name, double width, double height, double length,  decimal price)
        {
            CustomerId = customerid;
            Name = name;
            Width = width;
            Height = height;
            Length = length;
            Price = price;
        }
    }
}
