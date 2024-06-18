using Microsoft.AspNetCore.Mvc;
using Shareds.Contracts;
using Shareds.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts(bool featured)
        {
            var products = await _product.GetAllProduct(featured);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product model)
        {
            if (model is null) 
            { 
                return BadRequest("Model is Null");
            }
            var response = await _product.AddProduct(model);
            return Ok(response);
        }


    }
}
