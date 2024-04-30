using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //dummy data
        private static readonly List<Products> _product = new List<Products>
        {
            new Products
            {
                ProductId=1,
                ProductName="Dark Fantacy",
                brand=new Brands
                {
                     BrandId=1,
                     BrandName="Nescafe"
                },
                category=new Categories
                {
                    CategoryId=1,
                    CategoryName="Food"
                },
                ModelYear=2017,
                ListPrice=120
            }
        };
        #region Get All Categories

        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _product;
        }
        #endregion

        #region Get Brand by Id

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _product.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        #endregion

        #region Create a Product
       
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Products product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = _product.Count + 1;
                _product.Add(product);
                return Ok(_product);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Product by Id

        [HttpDelete("{id}")]
        public void DeleteProductById(int id)
        {
            var product = _product.FirstOrDefault(p => p.ProductId == id);
            _product.Remove(product);
        }
        #endregion

        #region Update Product by Id

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Products updatedProduct)
        {
            var updateProduct = _product.FirstOrDefault(p => p.ProductId == id);
            updateProduct.ProductName = updatedProduct.ProductName;
            updateProduct.brand = updatedProduct.brand;
            updateProduct.category = updatedProduct.category;
            updateProduct.ListPrice = updatedProduct.ListPrice;
            updateProduct.ModelYear=updatedProduct.ModelYear;
            return Ok(updateProduct);
        }

        #endregion
    }
}
