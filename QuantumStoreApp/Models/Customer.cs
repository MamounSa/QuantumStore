namespace QuantumStore
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; } // علاقة مع الطلبات

        public ICollection<Return> Returns { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; } // علاقة مع المراجعات

    }

}
