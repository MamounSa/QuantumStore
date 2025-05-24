
using Microsoft.EntityFrameworkCore;
using QuantumStore.DTOs;

namespace QuantumStore
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context; // سياق قاعدة البيانات

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(x=>x.ProductCategory).ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.Include(p=>p.ProductCategory).FirstOrDefault(p => p.Id == id);
            return product; // إعادة المنتج مع الفئة المرتبطة (إذا كانت موجودة)
        }


        public Product GetProductByName(string Name)
        {
            var product = _context.Products.Include(p=>p.ProductCategory).FirstOrDefault(p => p.Name == Name);
            return product; // إعادة المنتج مع الفئة المرتبطة (إذا كانت موجودة)
        }

        public bool AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = GetProductById(product.Id);
                if (existingProduct == null) return false; // المنتج غير موجود

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return false; // المنتج غير موجود
            try
            {
             
                _context.Products.Remove(product);
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
