using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuantumStore
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewService _reviewService;

        public ProductReviewController(IProductReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // استرجاع جميع المراجعات
        [HttpGet("getall")]
        public IActionResult GetAllReviews()
        {
            var reviews = _reviewService.GetAllReviews();
            if (reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound("No reviews found.");
        }

        // استرجاع مراجعة معينة بواسطة ID
        [HttpGet("getby{id}")]
        public IActionResult GetReviewById(int id)
        {
            var review = _reviewService.GetReviewById(id);
            if (review != null)
            {
                return Ok(review);
            }
            return NotFound($"Review with ID {id} not found.");
        }

        // إضافة مراجعة جديدة
        [HttpPost("add")]
        public IActionResult AddReview([FromBody] ProductReviewDTO reviewDto)
        {
            var success = _reviewService.AddReview(reviewDto);
            if (success)
            {
                return Ok("Review added successfully.");
            }
            return BadRequest("Failed to add review. Please ensure all fields are valid.");
        }

        // تعديل مراجعة موجودة
        [HttpPut("update{id}")]
        public IActionResult UpdateReview(int id, [FromBody] ProductReviewDTO reviewDto)
        {
            reviewDto.Id = id; // التأكد من أن ID يتطابق مع المدخل
            var success = _reviewService.UpdateReview(reviewDto);
            if (success)
            {
                return Ok("Review updated successfully.");
            }
            return NotFound($"Review with ID {id} not found.");
        }

        // حذف مراجعة بواسطة ID
        [HttpDelete("delete{id}")]
        public IActionResult DeleteReview(int id)
        {
            var success = _reviewService.DeleteReview(id);
            if (success)
            {
                return Ok("Review deleted successfully.");
            }
            return NotFound($"Review with ID {id} not found.");
        }
    }


}
