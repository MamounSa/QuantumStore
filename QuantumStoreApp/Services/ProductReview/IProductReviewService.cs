namespace QuantumStore
{
    public interface IProductReviewService
    {
        IEnumerable<ProductReviewDTO> GetAllReviews(); // جلب جميع المراجعات
        ProductReviewDTO GetReviewById(int id); // جلب مراجعة معينة بواسطة ID
        bool AddReview(ProductReviewDTO reviewDto); // إضافة مراجعة جديدة
        bool UpdateReview(ProductReviewDTO reviewDto); // تعديل مراجعة موجودة
        bool DeleteReview(int id); // حذف مراجعة بواسطة ID
    }

}
