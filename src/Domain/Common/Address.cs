using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace Domain.Common
{
    public class Address : ValueObject
    {
        public string Country { get; }
        public string City { get; }
        public string Postalcode { get; }
        public string Street { get; }

        public string Number { get; }

        public Address(string country, string city, string postalcode, string street, string number)
        {
            Country = Guard.Against.NullOrEmpty(country, nameof(country));
            City = Guard.Against.NullOrEmpty(city, nameof(city));
            Postalcode = Guard.Against.NullOrEmpty(postalcode, nameof(postalcode));
            Street = Guard.Against.NullOrEmpty(street, nameof(street));
            Number = Guard.Against.NullOrEmpty(number, nameof(number));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street.ToLower();
            yield return Country.ToLower();
            yield return Postalcode.ToLower();
            yield return City.ToLower();
            yield return Number.ToLower();
        }
    }
}