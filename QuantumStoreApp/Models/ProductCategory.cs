namespace QuantumStore
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } // علاقة مع المنتجات
    }

}
