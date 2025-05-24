namespace QuantumStore
{
    public interface IProductReviewRepository
    {
        IEnumerable<ProductReview> GetAllReviews(); // جلب جميع المراجعات
        ProductReview GetReviewById(int id); // جلب مراجعة معينة حسب ID
        bool AddReview(ProductReview review); // إضافة مراجعة جديدة
        bool UpdateReview(ProductReview review); // تحديث مراجعة موجودة
        bool DeleteReview(int id); // حذف مراجعة
    }

}
