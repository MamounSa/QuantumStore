using AutoMapper;
using QuantumStore.DTOs;

namespace QuantumStore
{
    namespace QuantumStore
    {
        public class ProductCategoryService : IProductCategoryService
        {
            private readonly IProductCategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public ProductCategoryService(IProductCategoryRepository categoryRepository,IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            // استرجاع جميع الفئات
            public IEnumerable<ProductCategoryDTO> GetAllCategories()
            {
                var categories = _categoryRepository.GetAllCategories();
                if (categories == null)
                {
                    return Enumerable.Empty<ProductCategoryDTO>();
                }
                var categoryDTOs = categories.Select(cat => _mapper.Map<ProductCategoryDTO>(cat));
                return categoryDTOs;
            }

            // استرجاع فئة معينة بواسطة ID
            public ProductCategoryDTO GetCategoryById(int id)
            {
                var category = _categoryRepository.GetCategoryById(id);
                return category != null ? _mapper.Map<ProductCategoryDTO>(category) : null;
            }
            public ProductCategoryDTO GetCategoryByName(string Name)
            {
                var category = _categoryRepository.GetCategoryByName(Name);
                return category != null ? _mapper.Map<ProductCategoryDTO>(category) : null;
            }
            // إضافة فئة جديدة
            public bool AddCategory(ProductCategoryDTO categoryDTO)
            {
                if (!ValidateCategoryData(categoryDTO, out string validationError))
                {
                    Console.WriteLine($"Validation Failed: {validationError}");
                    return false; // البيانات غير صالحة
                }

                var category = _mapper.Map<ProductCategory>(categoryDTO);
                return _categoryRepository.AddCategory(category);
            }

            // تحديث فئة موجودة
            public bool UpdateCategory(ProductCategoryDTO categoryDTO)
            {
                var existingCategory = _categoryRepository.GetCategoryById(categoryDTO.Id);
                if (existingCategory == null) return false; // الفئة غير موجودة
                var updatedcategory = _mapper.Map(categoryDTO, existingCategory);

                return _categoryRepository.UpdateCategory(updatedcategory);
            }

            // حذف فئة
            public bool DeleteCategory(int id)
            {
                var category = _categoryRepository.GetCategoryById(id);
                if (category == null) return false; // الفئة غير موجودة

                return _categoryRepository.DeleteCategory(id);
            }

            // دالة لتحويل الفئة إلى DTO
            private ProductCategoryDTO MapToDTO(ProductCategory category)
            {
                return new ProductCategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    ProductCount = category.Products?.Count ?? 0 // عدد المنتجات المرتبطة
                };
            }

            // دالة لتحويل DTO إلى كيان
            private ProductCategory MapToEntity(ProductCategoryDTO categoryDTO)
            {
                return new ProductCategory
                {
                    Id = categoryDTO.Id,
                    Name = categoryDTO.Name
                };
            }

            // التحقق من صحة البيانات
            private bool ValidateCategoryData(ProductCategoryDTO categoryDTO, out string validationError)
            {
                validationError = string.Empty;

                if (string.IsNullOrWhiteSpace(categoryDTO.Name))
                {
                    validationError = "Category name is required.";
                    return false;
                }

                return true; // البيانات صحيحة
            }

           
        }
    }

}
