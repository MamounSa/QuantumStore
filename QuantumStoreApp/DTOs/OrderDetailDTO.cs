namespace QuantumStore
{
    public class OrderDetailDTO
    {
        public int Id { get; set; } // معرف التفاصيل
        public int OrderId { get; set; } // معرف الطلب
        public int ProductId { get; set; } // معرف المنتج
        public int Quantity { get; set; } // الكمية
        public decimal TotalPrice { get; set; } // السعر الإجمالي
    }

}
