using DemoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //dummy data
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1,Name="Computer",Price=2000.00m},
            new Product { Id = 2,Name="Phone",Price=500.00m},

        };
        #region Get All Products
        //Get products (endpoint: api/Products)
        [HttpGet]
        public IEnumerable<Product>GetProducts()
        {
            return _products;
        }
        #endregion

        #region Get Product by Id
        //GET : api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product= _products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        #endregion

        #region Create a product
        //POST : api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if(ModelState.IsValid)
            {
                product.Id = _products.Count + 1;
                _products.Add(product);
                return Ok(product);
            }
            return BadRequest(ModelState);
        }
        #endregion
    }
}
