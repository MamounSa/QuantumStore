namespace QuantumStore
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // علاقة مع الطلب
        public int ProductId { get; set; }
        public Product Product { get; set; } // علاقة مع المنتج
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
