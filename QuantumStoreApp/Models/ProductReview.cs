namespace QuantumStore
{
    public class ProductReview
    {
        public int Id { get; set; } // معرف المراجعة (Primary Key)
        public string ReviewText { get; set; } // النص الخاص بالمراجعة
        public int Rating { get; set; } // التقييم (1-5)
        public DateTime ReviewDate { get; set; } // تاريخ المراجعة

        // العلاقة مع المنتج
        public int ProductId { get; set; } // معرف المنتج (Foreign Key)
        public Product Product { get; set; } // المنتج المرتبط

        // العلاقة مع العميل
        public int CustomerId { get; set; } // معرف العميل (Foreign Key)
        public Customer Customer { get; set; } // العميل الذي قام بالمراجعة
    }



}
