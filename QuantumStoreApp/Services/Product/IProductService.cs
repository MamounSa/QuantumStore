using QuantumStore.DTOs;

namespace QuantumStore
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts(); // جلب جميع المنتجات
        ProductDTO GetProductById(int id); // جلب منتج معين باستخدام ID
        public ProductDTO GetProductByName(string Name);
        bool AddProduct(ProductDTO product); // إضافة منتج جديد (ترجع true عند النجاح)
        bool UpdateProduct(ProductDTO product); // تعديل منتج (ترجع true عند النجاح)
        bool DeleteProduct(int id); // حذف منتج (ترجع true عند النجاح)
    }

}
