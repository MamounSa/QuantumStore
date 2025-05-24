namespace QuantumStore
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategoryDTO> GetAllCategories();
        ProductCategoryDTO GetCategoryById(int id);
        public ProductCategoryDTO GetCategoryByName(string Name);
        bool AddCategory(ProductCategoryDTO categoryDTO);
        bool UpdateCategory(ProductCategoryDTO categoryDTO);
        bool DeleteCategory(int id);
    }

}
