using Microsoft.EntityFrameworkCore;

namespace QuantumStore
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly AppDbContext _context; // سياق قاعدة البيانات

        public ProductReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        // جلب جميع المراجعات
        public IEnumerable<ProductReview> GetAllReviews()
        {
            return _context.ProductReviews.Include(x=>x.Product).ToList();
        }

        // جلب مراجعة معينة حسب ID
        public ProductReview GetReviewById(int id)
        {
            return _context.ProductReviews.Include(x => x.Product).FirstOrDefault(r => r.Id == id);
        }

        // إضافة مراجعة جديدة
        public bool AddReview(ProductReview review)
        {
            try
            {
                _context.ProductReviews.Add(review);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        // تحديث مراجعة موجودة
        public bool UpdateReview(ProductReview review)
        {
            try
            {
                var existingReview = GetReviewById(review.Id);
                if (existingReview == null) return false; // المراجعة غير موجودة

                existingReview.ReviewText = review.ReviewText;
                existingReview.ProductId = review.ProductId;
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        // حذف مراجعة
        public bool DeleteReview(int id)
        {
            var review = GetReviewById(id);
            if (review == null) return false; // المراجعة غير موجودة
            try
            {
                _context.ProductReviews.Remove(review);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }
    }

}
