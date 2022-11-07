using FluentValidation;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Orders
{
    public class OrderDto
    {
        public class Index
        {
            public int Id { get; set; }
            public decimal Price { get; set; }

            public DateTime ArrivalDate { get; set; }
        }

        public class Detail : Index
        {
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
            public AddressDto.Index Address { get; set; }
            public List<OrderLineDto.Index> OrderLines { get; set; }

        }

        public class Mutate
        {
            public int CustomerId { get; set; }

            public AddressDto.Index Address { get; set; }

            public List<OrderLineDto.Index> OrderLines { get; set; }

            public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Address).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Address is required");
                    RuleFor(x => x.OrderLines).NotEmpty();
                }
            }

        }

    }
}
