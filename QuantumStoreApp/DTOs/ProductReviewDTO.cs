namespace QuantumStore
{
    public class ProductReviewDTO
    {
        public int Id { get; set; } // معرف المراجعة
        public string ReviewText { get; set; } // نص المراجعة
        public int ProductId { get; set; } // معرف المنتج المرتبط
        public string ProductName { get; set; } // اسم المنتج (اختياري)
    }

}
