using System.Collections.Generic;

namespace Shared.Boxes
{
    public static class BoxResponse
    {
        public class GetIndex
        {
            public List<BoxDto.Index> Boxes { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public BoxDto.Detail Box { get; set; }
        }

        public class Delete
        {

        }

        public class Create
        {
            public int BoxId { get; set; }
        }

        public class Edit
        {
            public int BoxId { get ; set; }
        }
    }
}
