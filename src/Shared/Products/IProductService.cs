using Shared.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Products
{
    public interface IProductService
    {

        Task<ProductResponse.GetIndex> GetIndexAsync(ProductRequest.GetIndex request);

    }
}
