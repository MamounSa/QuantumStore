using AutoMapper.Configuration.Annotations;

namespace QuantumStore
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; } // عدد المنتجات المرتبطة بالفئة

        
        
    }

}
