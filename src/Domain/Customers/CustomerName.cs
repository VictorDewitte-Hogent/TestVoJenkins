using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public class CustomerName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        public CustomerName(string firstName, string lastName)
        {
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName.ToLower();
            yield return LastName.ToLower();
        }

    }
}
