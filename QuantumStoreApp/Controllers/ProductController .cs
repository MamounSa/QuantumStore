using Microsoft.AspNetCore.Mvc;
using QuantumStore.DTOs;
namespace QuantumStore
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            var productsDTOs = _productService.GetAllProducts();



            if (productsDTOs.Any())
            {
                return Ok(productsDTOs);
            }
            return NotFound("No products found.");
        }

        [HttpGet("get/{id}")]
        public IActionResult GetProductById(int id)
        {
            var productDTO = _productService.GetProductById(id);

            if (productDTO != null)
            {
                
                return Ok(productDTO);
            }
            return NotFound($"Product with ID {id} not found.");
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            
            var success = _productService.AddProduct(productDTO);

            if (success)
            {
                return Ok("Product added successfully.");
            }
            return BadRequest("Failed to add product. Please check your input.");
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {

            var success = _productService.UpdateProduct(productDTO);
            if (success)
            {
                return Ok("Product updated successfully.");
            }
            return NotFound($"Product with ID {id} not found.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var success = _productService.DeleteProduct(id);

            if (success)
            {
                return Ok("Product deleted successfully.");
            }
            return NotFound($"Product with ID {id} not found.");
        }

        
        
    }
}