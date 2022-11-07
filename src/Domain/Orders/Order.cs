using Domain.Common;
using Domain.Orders;
using Domain.Customers;

namespace Domain.Orders
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; }
        public Address ShippingAddress { get; }
        public Status Status { get; set; }
        public DeliveryData DeliveryData {get; set;}
        public List<OrderLine> Items { get; set;} = new List<OrderLine>();
        public decimal Total { get; set;}
        public int CustomerId { get; set; }
        public Order(Address shippingAddress, List<OrderLine> items, int customerId)
        {
            OrderDate = DateTime.UtcNow;
            Status = Status.PROCESSING;
            ShippingAddress = shippingAddress;
            //TODO: Fix start locaties
            DeliveryData = new DeliveryData(51.59979128829661, 4.307057380401206F);
            Items = items;
            Total = CalculatePrize(items);
            CustomerId = customerId;
        }

        //TODO: Fix deftige finale prijsberekening
        private decimal CalculatePrize(List<OrderLine> items) {
            return items.Sum(line => line.Price) + 100;
        }
    }
}


