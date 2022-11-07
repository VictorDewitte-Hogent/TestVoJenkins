using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
namespace Domain.Products
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            
            CustomInstantiator(f => new Product(f.Commerce.ProductName(), f.Random.Decimal(0,200), f.Random.Float(0, 20), f.Random.Float(0, 20), f.Random.Float(0, 20), new CategoryFaker()));
            RuleFor(x => x.Id, f => f.Random.Int(1));
            UseSeed(1337);
        }
    }
}
