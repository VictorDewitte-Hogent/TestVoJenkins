using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Domain.Common;
namespace Domain.Products
{
    public  class CategoryFaker : Faker<Category>
    {
        public CategoryFaker()
        {
            CustomInstantiator(f => new Category(f.Commerce.ProductMaterial()));
            RuleFor(x => x.Id, f => f.Random.Int());
        }
    }
}
