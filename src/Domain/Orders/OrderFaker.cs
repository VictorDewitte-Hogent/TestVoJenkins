using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Customers;

namespace Domain.Orders
{
    public class OrderFaker : Faker<Order>
    {
        
        public OrderFaker()
        {
            var orderLineFaker = new OrderLineFaker();
            CustomInstantiator(f =>
            new Order(
                new Domain.Common.Address(f.Address.Country(), f.Address.City(), f.Address.ZipCode(), f.Address.StreetName(), f.Address.BuildingNumber()),
                orderLineFaker.Generate(f.Random.Int(1, 8)),
                f.Random.Int(1, 8))
            );
            RuleFor(x => x.Id, f => f.Random.Int(1));
            UseSeed(1337);
        }
    }
}
