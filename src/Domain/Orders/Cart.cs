using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Products;

namespace Domain.Orders
{
    public class Cart
    {
        private readonly List<CartLine> _cartlines = new();

        public IReadOnlyList<CartLine> Lines => _cartlines.AsReadOnly();
        public decimal Total => _cartlines.Sum(x => x.Total);

        public CartLine AddItem(Product product, int quantity)
        {
            var existingLine = _cartlines.SingleOrDefault(x => x.Product.Equals(product));
            if (existingLine is not null)
            {
                existingLine.IncreaseQuantity(quantity);
                return existingLine;
            }
            else
            {
                CartLine line = new CartLine(product, quantity);
                _cartlines.Add(line);
                return line;
            }
        }

        public void RemoveLine(Product product)
        {
            CartLine line = _cartlines.SingleOrDefault(l => l.Product.Equals(product));
            if (line != null) _cartlines.Remove(line);
        }

        public void Clear()
        {
            _cartlines.Clear();
        }
    }
}
