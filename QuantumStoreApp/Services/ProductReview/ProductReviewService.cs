using AutoMapper;

namespace QuantumStore
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ProductReviewService(IProductReviewRepository reviewRepository,IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        // جلب جميع المراجعات
        public IEnumerable<ProductReviewDTO> GetAllReviews()
        {
            var reviews = _reviewRepository.GetAllReviews();
          
            return reviews == null? Enumerable.Empty<ProductReviewDTO>()
                : reviews.Select(r => _mapper.Map<ProductReviewDTO>(r));
        }

        // جلب مراجعة معينة بواسطة ID
        public ProductReviewDTO GetReviewById(int id)
        {
            var review = _reviewRepository.GetReviewById(id);
            return review != null ? _mapper.Map<ProductReviewDTO>(review) : null;
        }

        // إضافة مراجعة جديدة
        public bool AddReview(ProductReviewDTO reviewDto)
        {
            if (!ValidateReviewData(reviewDto, out string validationError))
            {
               // Console.WriteLine($"Validation Failed: {validationError}");
                return false; // البيانات غير صالحة
            }

            var review = _mapper.Map<ProductReview>(reviewDto);
            return _reviewRepository.AddReview(review);
        }

        // تعديل مراجعة موجودة
        public bool UpdateReview(ProductReviewDTO reviewDto)
        {
            if (!ValidateReviewData(reviewDto, out string validationError))
            {
                Console.WriteLine($"Validation Failed: {validationError}");
                return false; // البيانات غير صالحة
            }
            var existingReview = _reviewRepository.GetReviewById(reviewDto.Id);
            return existingReview == null ? false
             : _reviewRepository.UpdateReview(_mapper.Map(reviewDto, existingReview));
        }

        // حذف مراجعة بواسطة ID
        public bool DeleteReview(int id)
        {
            var review = _reviewRepository.GetReviewById(id);
            return review == null ? false : _reviewRepository.DeleteReview(id);
        }

        // تحويل المراجعة إلى DTO
        

        // التحقق من صحة بيانات المراجعة
        private bool ValidateReviewData(ProductReviewDTO reviewDto, out string validationError)
        {
            validationError = string.Empty;

            if (string.IsNullOrWhiteSpace(reviewDto.ReviewText))
            {
                validationError = "Review text is required.";
                return false;
            }

            if (reviewDto.ProductId <= 0)
            {
                validationError = "Invalid Product ID.";
                return false;
            }

            return true; // البيانات صحيحة
        }
    }

}
