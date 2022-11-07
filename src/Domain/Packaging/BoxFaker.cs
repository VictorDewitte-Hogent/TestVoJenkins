using Bogus;
using Domain.Common;
namespace Domain.Packaging
{
    public class BoxFaker : Faker<Box>
    {
        public BoxFaker()
        {
            CustomInstantiator(f => new Box(1, f.Commerce.ProductName(), f.Random.Double(1, 250), f.Random.Double(1, 250), f.Random.Double(1, 250)));
            RuleFor(x => x.Id, f => f.Random.Int(1));
            UseSeed(1337);
        }
    }
}
