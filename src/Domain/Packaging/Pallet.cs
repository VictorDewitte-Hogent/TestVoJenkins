using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Packaging
{
    public class Pallet
    {
        private const double height = 150;
        public double Width { get; }
        public double Depth { get; }
        public decimal Price { get; }
        public Pallet(double width, double depth, decimal price)
        {
            Width = width;
            Depth = depth;
            Price = price;
        }

        //TODO: Make this algorithm more flexible
        public int HowManyBoxesFit(double widthBox, double heightBox, double depthBox)
        {
            if (widthBox > Width || heightBox > height || depthBox > Depth) return 0;
            int nrWidth = (int)(Width / widthBox);
            int nrHeight = (int)(height/ heightBox);
            int nrDepth = (int)(Depth / depthBox);
            return nrWidth * nrHeight *nrDepth;        
        }
    }
}
