using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        //dummy data
        private static readonly List<Brands> _brand = new List<Brands>
        {
            new Brands
            {
                BrandId=1,
                BrandName="Nescafe",
            }
        };
        #region Get All Brands

        [HttpGet]
        public IEnumerable<Brands> GetBrands()
        {
            return _brand;
        }
        #endregion

        #region Get Brand by Id

        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            var brand = _brand.FirstOrDefault(p => p.BrandId == id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        #endregion

        #region Create a Brand
      
        [HttpPost]
        public IActionResult CreateBrand([FromBody] Brands brand)
        {
            if (ModelState.IsValid)
            {
                brand.BrandId = _brand.Count + 1;
                _brand.Add(brand);
                return Ok(_brand);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Brand by Id

        [HttpDelete("{id}")]
        public void DeleteBrandById(int id)
        {
            var brand = _brand.FirstOrDefault(p => p.BrandId == id);
            _brand.Remove(brand);
        }
        #endregion

        #region Update Brand by Id

        [HttpPut("{id}")]
        public IActionResult UpdateBrand(int id, [FromBody] Brands updatedBrand)
        {
            var updateBrand = _brand.FirstOrDefault(p => p.BrandId == id);
            updateBrand.BrandName = updatedBrand.BrandName;
            return Ok(updateBrand);
        }

        #endregion
    }
}
