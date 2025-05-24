namespace QuantumStore
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }
        public int? ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } // علاقة مع الفئات
        public ICollection<ProductReview> ProductReviews { get; set; } // علاقة مع المراجعات
        public Discount Discount { get; set; }
        public int? DiscountId {  get; set; }

        public ICollection<Inventory> InventoryRecords { get; set; }
    }

}
