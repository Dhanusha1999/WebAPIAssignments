using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //dummy data
        private static readonly List<Categories> _category = new List<Categories>
        {
            new Categories
            {
                CategoryId=1,
                CategoryName="Food",
            }
        };
        #region Get All Categories
       
        [HttpGet]
        public IEnumerable<Categories> GetCategory()
        {
            return _category;
        }
        #endregion

        #region Get Category by Id
      
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _category.FirstOrDefault(p => p.CategoryId== id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        #endregion

        #region Create a Category
        //POST : api/customers
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Categories category)
        {
            if (ModelState.IsValid)
            {
                category.CategoryId = _category.Count + 1;
                _category.Add(category);
                return Ok(_category);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Category by Id
       
        [HttpDelete("{id}")]
        public void DeleteCategoryById(int id)
        {
            var category = _category.FirstOrDefault(p => p.CategoryId == id);
            _category.Remove(category);
        }
        #endregion

        #region Update Category by Id
      
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Categories updatedCategory)
        {
            var updateCategory = _category.FirstOrDefault(p => p.CategoryId == id);
            updateCategory.CategoryName = updatedCategory.CategoryName;
            return Ok(updateCategory);
        }

        #endregion
    }
}
