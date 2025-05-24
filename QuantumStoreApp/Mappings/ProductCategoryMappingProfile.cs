using AutoMapper;

namespace QuantumStore
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDTO>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products.Count));

            CreateMap<ProductCategoryDTO, ProductCategory>();
    
        }
    }
}
