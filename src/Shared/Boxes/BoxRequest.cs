using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Boxes
{
    public static class BoxRequest
    {
        public class GetIndex
        {
            public int CustomerId { get; set; }
            public int Page { get; set; }
            public int Amount { get; set; } = 25;
        }

        public class GetDetail
        {
            public int BoxId { get; set; }
        }

        public class Delete
        {
            public int BoxId { get; set; }
        }

        public class Create
        {
            public BoxDto.Mutate Box { get; set; }
        }

        public class Edit
        {
            public int BoxId { get; set; }
            public BoxDto.Mutate Box { get; set; }
        }
    }
}
