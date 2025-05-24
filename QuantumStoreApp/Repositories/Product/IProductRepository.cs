
using QuantumStore.DTOs;

namespace QuantumStore
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); // جلب جميع المنتجات
        Product GetProductById(int id); // جلب منتج معين باستخدام ID
        Product GetProductByName(string Name); // جلب منتج معين باستخدام ID

        bool AddProduct(Product product); // إضافة منتج جديد (ترجع true عند النجاح)
        bool UpdateProduct(Product product); // تحديث منتج (ترجع true عند النجاح)
        bool DeleteProduct(int id); // حذف منتج (ترجع true عند النجاح)
    }


}
