using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Customers
{
    public class Customer : Entity
    {
        public CustomerName Name { get; private set; }
        public Address Address { get; private set; }
        public List<Order> Orders { get; set; }

        public Customer(CustomerName name)
        {
            Name = Guard.Against.Null(name, nameof(name));
        }
        public Customer(CustomerName name, Address address)
        {
            Name = Guard.Against.Null(name, nameof(name));
            Address = Guard.Against.Null(address, nameof(address));
        }

        public Order PlaceOrder(Address shippingAddress, List<OrderLine> items)
        {
            var order = new Order(shippingAddress, items, this.Id);
            Orders.Add(order);
            return order;
        }
    }
}
