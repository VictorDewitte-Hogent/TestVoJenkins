using Domain.Common;
using Domain.Packaging;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class OrderLine : Entity
    {
        public Product Product { get; }
        public int Quantity { get; }
        public Box Box { get; }
        public Pallet Pallet { get; }
        public int NrOfPallets { get; }
        public decimal Price => NrOfPallets * Pallet.Price + (Quantity * (Product.Price + Box.Price));

        public OrderLine(Product product, int quantity, Box box, Pallet pallet, int nrOfPallets)
        {
            Product = product;
            Quantity = quantity;
            Box = box;
            Pallet = pallet;
            NrOfPallets = nrOfPallets;
        }
    }
}
