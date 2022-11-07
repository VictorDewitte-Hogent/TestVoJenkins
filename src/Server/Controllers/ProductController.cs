using Microsoft.AspNetCore.Mvc;
using Shared.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet]
        public Task<ProductResponse.GetIndex> GetIndexAsync([FromQuery] ProductRequest.GetIndex request)
        {
            return productService.GetIndexAsync(request);
        }
    }

