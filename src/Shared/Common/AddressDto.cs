using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class AddressDto
    {
        public class Index
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }

        }
    }
}
