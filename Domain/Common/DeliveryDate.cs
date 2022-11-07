using System;
namespace Domain.Common
{
    public class DeliveryDate : ValueObject
    {
        public DateTime Date { get; }

        public DeliveryDate(DateTime deliveryDate)
        {
            this.Date = deliveryDate;
            this.Date = new DateTime
            
        }
    }
}


