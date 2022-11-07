using Domain.Common;

namespace Domain.Products
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name)
        {
            this.Name = name;
        }
    }
}


