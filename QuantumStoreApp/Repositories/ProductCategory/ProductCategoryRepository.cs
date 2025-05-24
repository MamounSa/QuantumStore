
using Microsoft.EntityFrameworkCore;

namespace QuantumStore
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context; // سياق قاعدة البيانات

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        // جلب جميع الفئات
        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return _context.ProductCategories.Include(x=>x.Products);
        }

        // جلب فئة معينة بواسطة Id
        public ProductCategory GetCategoryById(int id)
        {
            return _context.ProductCategories.Include(x => x.Products).FirstOrDefault(c => c.Id == id);
        }
        public ProductCategory GetCategoryByName(string Name)
        {
            return _context.ProductCategories.Include(x => x.Products).FirstOrDefault(c => c.Name == Name);
        }

        // إضافة فئة جديدة
        public bool AddCategory(ProductCategory category)
        {
            try
            {
                _context.ProductCategories.Add(category);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        // تحديث فئة موجودة
        public bool UpdateCategory(ProductCategory category)
        {
            try
            {
                var existingCategory = GetCategoryById(category.Id);
                if (existingCategory == null) return false; // الفئة غير موجودة

                existingCategory.Name = category.Name;
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        // حذف فئة بواسطة Id
        public bool DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category == null) return false; // الفئة غير موجودة
            try
            {
                _context.ProductCategories.Remove(category);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }
    }
}
    


