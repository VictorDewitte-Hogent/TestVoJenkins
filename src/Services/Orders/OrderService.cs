using Shared.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders;
using Domain.Common;
using Domain.Products;
using Domain.Packaging;
using Shared.Common;
using Shared.Boxes;

namespace Services.Orders
{
    public class OrderService : IOrderService
    {
        private static readonly List<Order> orders = new();

        static OrderService()
        {
            var orderFaker = new OrderFaker();
            orders = orderFaker.Generate(20);
        }

        // TODO: Stem deze beter af op Dto's met Id's
        public async Task<OrderResponse.Create> CreateAsync(OrderRequest.Create request)
        {
            await Task.Delay(100);
            OrderResponse.Create response = new();

            var model = request.Order;
            var address = new Address(request.Order.Address.Country, request.Order.Address.City, request.Order.Address.PostalCode, request.Order.Address.Street, request.Order.Address.Number);
            var order = new Order(address, request.Order.OrderLines.Select(x =>
            {
                // TODO: OrderDto's moeten Product Id's bevatten die we kunnen ophalen uit de databank
                var product = new Product(x.ProductName, 1, 1, 1, 1, new Category("TODO: CategoryName"));
                var box = new Box(x.Box.CustomerId, x.Box.Name, x.Box.Width, x.Box.Height, x.Box.Length);
                // TODO: Zelfde voor pallets als orders
                var pallet = new Pallet(1, 1, 1);

                return new OrderLine(product, x.Quantity, box, pallet, x.NrOfPallets);
            }).ToList(), request.Order.CustomerId)
            {
                Id = orders.Max(x => x.Id) + 1
            };

            orders.Add(order);
            response.OrderId = order.Id;

            return response;
        }

        public async Task DeleteAsync(OrderRequest.Delete request)
        {
            await Task.Delay(100);
            var o = orders.SingleOrDefault(x => x.Id == request.OrderId);
            orders.Remove(o);
        }

        public async Task<OrderResponse.Edit> EditAsync(OrderRequest.Edit request)
        {
            await Task.Delay(100);
            OrderResponse.Edit response = new(); 
            var order = orders.SingleOrDefault(x => x.Id == request.OrderId);
            var model = request.Order;
            // TODO: Edit implementeren
            response.OrderId = order.Id;
            return response;
        }

        public async Task<OrderResponse.GetDetail> GetDetailAsync(OrderRequest.GetDetail request)
        {
            await Task.Delay(100);
            OrderResponse.GetDetail response = new();
            response.Order = orders.Select(x => new OrderDto.Detail
            {
                Id = x.Id,
                Price = 0,
                ArrivalDate = DateTime.UtcNow,
                OrderDate = x.OrderDate.ToUniversalTime(),
                Status = x.Status.ToString(),
                Address = new AddressDto.Index { Country = x.ShippingAddress.Country, City = x.ShippingAddress.City, PostalCode = x.ShippingAddress.Postalcode, Street = x.ShippingAddress.Street, Number = x.ShippingAddress.Number},
                OrderLines = x.Items.Select(line => new OrderLineDto.Index { Box = new BoxDto.Index { Id = line.Box.Id,  CustomerId = line.Box.CustomerId, Height = (int) line.Box.Height, Length = (int) line.Box.Length, Name = line.Box.Name, Width = (int) line.Box.Width} }).ToList()
            }).SingleOrDefault(x => x.Id == request.OrderId);
            return response;
        }

        public async Task<OrderResponse.GetIndex> GetIndexAsync(OrderRequest.GetIndex request)
        {
            await Task.Delay(100);
            OrderResponse.GetIndex response = new();
            var query = orders.AsQueryable();

            query = query.Where(x => x.CustomerId == request.CustomerId);
            response.TotalAmount = query.Count();

            query = query.Skip(request.Amount * request.Page);
            query = query.Take(request.Amount);

            query.OrderBy(x => x.CustomerId);
            response.Orders = query.Select(x => new OrderDto.Index
            {
                Id = x.Id,
                ArrivalDate = DateTime.UtcNow,
                Price = x.Total,
            }).ToList();

            return response;
        }
    }
}
