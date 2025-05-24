namespace QuantumStore
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; } // اسم العرض
        public decimal DiscountAmount { get; set; } // مقدار الخصم
        public ICollection<Product> Products { get; set; } // علاقة مع المنتجات
    }

}
