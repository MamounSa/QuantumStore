using QuantumStore.DTOs;

namespace QuantumStore
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetAllCategories(); // جلب جميع الفئات
        ProductCategory GetCategoryById(int id); // جلب فئة معينة باستخدام Id

        public ProductCategory GetCategoryByName(string Name);
        bool AddCategory(ProductCategory category); // إضافة فئة جديدة
        bool UpdateCategory(ProductCategory category); // تحديث فئة موجودة
        bool DeleteCategory(int id); // حذف فئة باستخدام Id
    }

}
