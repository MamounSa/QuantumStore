namespace QuantumStore
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; } // علاقة مع السلة
        public int ProductId { get; set; }
        public Product Product { get; set; } // علاقة مع المنتج
        public int Quantity { get; set; } // عدد القطع
    }

}
