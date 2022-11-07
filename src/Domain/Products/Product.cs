using Domain.Common;

namespace Domain.Products
{
    public class Product : Entity
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }

        public Product(string name, decimal price, float width, float height, float depth, Category category)
        {
            this.Name = name;
            this.Price = price;
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.Category = category;
        }
    }
}


