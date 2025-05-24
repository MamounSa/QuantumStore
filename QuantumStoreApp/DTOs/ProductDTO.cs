namespace QuantumStore.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; } // معرف المنتج
        public string Name { get; set; } // اسم المنتج
        public decimal Price { get; set; } // سعر المنتج
        public DateTime ExpirationDate { get; set; } // تاريخ انتهاء الصلاحية

        // اسم الفئة (اختياري)
        public int ProductCategoryId {  get; set; }
        public string ProductCategoryName { get; set; }

        // معدل الخصم (اختياري)
        public decimal? DiscountRate { get; set; }

        // الكمية المتوفرة في المخزون
        public int TotalInventoryQuantity { get; set; }

        public ProductCategoryDTO ProductCategory { get; set; }
    }


}
