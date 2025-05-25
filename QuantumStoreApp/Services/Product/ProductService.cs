using AutoMapper;
using QuantumStore;
using QuantumStore.DTOs;

namespace QuantumStore
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _productCategoryService;

        public ProductService(IProductRepository productRepository,IMapper mapper, IProductCategoryService productCategoryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productCategoryService = productCategoryService;
        }

        // استرجاع جميع المنتجات
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            if (products == null)
            {
                return Enumerable.Empty<ProductDTO>();
            }

            return products.Select(x=>_mapper.Map<ProductDTO>(x));
        }

        // استرجاع منتج بواسطة ID
        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product != null ? _mapper.Map<ProductDTO>(product) : null;
        }

        // استرجاع منتج بواسطة الاسم
        public ProductDTO GetProductByName(string name)
        {
            var product = _productRepository.GetProductByName(name);
            return product != null ? _mapper.Map<ProductDTO>(product) : null;
        }

        // إضافة منتج جديد
        public bool AddProduct(ProductDTO productDTO)
        {
            if (!ValidateProductData(productDTO, out string validationError))
            {
                Console.WriteLine($"Validation Failed: {validationError}");
                return false; // العملية فشلت بسبب البيانات غير الصالحة
            }

            try
            {
                var product = _mapper.Map<Product>(productDTO);
                _productRepository.AddProduct(product);
                return true; // تم الإضافة بنجاح
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Adding Product: {ex.Message}");
                return false; // فشل الإضافة بسبب خطأ
            }
        }
		public IEnumerable<ProductDTO> GetAllProductsByExpirationDate(DateTime  dateTime)
  			{
            var products = _productRepository.GetAllProductsByExpirationDate();
            if (products == null)
            {
                return Enumerable.Empty<ProductDTO>();
            }

            return products.Select(x=>_mapper.Map<ProductDTO>(x));
            }
        // تحديث منتج موجود
        public bool UpdateProduct(ProductDTO productDTO)
        {
            var existingProduct = _productRepository.GetProductById(productDTO.Id);

            if (existingProduct == null)
            {
                return false; // المنتج غير موجود
            }

            // تحديث الحقول فقط عند الحاجة
            var updatedProduct = _mapper.Map(productDTO, existingProduct);
            try
            {
                _productRepository.UpdateProduct(updatedProduct);
                return true; // تم التعديل بنجاح
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Updating Product: {ex.Message}");
                return false; // فشل التعديل بسبب خطأ
            }
        }

        // حذف منتج بواسطة ID
        public bool DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return false; // المنتج غير موجود
            }

            try
            {
                _productRepository.DeleteProduct(id);
                return true; // تم الحذف بنجاح
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting Product: {ex.Message}");
                return false; // فشل الحذف بسبب خطأ
            }
        }

        // التحقق من صحة بيانات المنتج
        private bool ValidateProductData(ProductDTO productDTO, out string validationError)
        {
            validationError = string.Empty;

            if (string.IsNullOrWhiteSpace(productDTO.Name))
            {
                validationError = "Product name is required.";
                return false;
            }

            if (productDTO.Price <= 0)
            {
                validationError = "Product price must be greater than 0.";
                return false;
            }

            if (productDTO.ExpirationDate <= DateTime.Now)
            {
                validationError = "Product expiration date must be in the future.";
                return false;
            }

            return true; // البيانات صحيحة
        }
		
    }
}
