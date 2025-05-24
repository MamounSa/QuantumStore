namespace QuantumStore
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // علاقة مع العميل
        public ICollection<CartItem> Items { get; set; } // علاقة مع العناصر
    }

}
