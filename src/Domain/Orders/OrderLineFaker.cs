using Bogus;
using Domain.Packaging;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class OrderLineFaker : Faker<OrderLine>
    {
        public OrderLineFaker()
        {
            var productFaker = new ProductFaker();
            var boxFaker = new BoxFaker();
            CustomInstantiator(f => new OrderLine(
                productFaker.Generate(1).First(),
                f.Random.Int(1, 200),
                boxFaker.Generate(1).First(),
                new Pallet(f.Random.Double(1,250), f.Random.Double(1, 250), f.Random.Decimal(1, 250)),
                f.Random.Int(1, 5)));
            RuleFor(x => x.Id, f => f.Random.Int(1));
            UseSeed(1337);
        }
    }
}
