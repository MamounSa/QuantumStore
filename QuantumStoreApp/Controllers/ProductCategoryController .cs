using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuantumStore
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _categoryService;

        public ProductCategoryController(IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // استرجاع جميع الفئات
        [HttpGet("getall")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            if (categories.Any())
            {
                return Ok(categories);
            }
            return NotFound("No categories found.");
        }

        // استرجاع فئة معينة بواسطة ID
        [HttpGet("getby{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound($"Category with ID {id} not found.");
        }

        // إضافة فئة جديدة
        [HttpPost("add")]
        public IActionResult AddCategory([FromBody] ProductCategoryDTO categoryDto)
        {
            var success = _categoryService.AddCategory(categoryDto);
            if (success)
            {
                return Ok("Category added successfully.");
            }
            return BadRequest("Failed to add category. Please ensure all fields are correct.");
        }

        // تحديث فئة موجودة
        [HttpPut("update{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] ProductCategoryDTO categoryDto)
        {
            categoryDto.Id = id; // تأكيد أن ID الفئة يتم تحديثه بناءً على الطلب
            var success = _categoryService.UpdateCategory(categoryDto);
            if (success)
            {
                return Ok("Category updated successfully.");
            }
            return NotFound($"Category with ID {id} not found.");
        }

        // حذف فئة بواسطة ID
        [HttpDelete("delete{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var success = _categoryService.DeleteCategory(id);
            if (success)
            {
                return Ok("Category deleted successfully.");
            }
            return NotFound($"Category with ID {id} not found.");
        }
    }

}
