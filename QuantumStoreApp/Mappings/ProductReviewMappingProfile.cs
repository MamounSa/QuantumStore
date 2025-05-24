using AutoMapper;

namespace QuantumStore
{
    public class ProductReviewMappingProfile:Profile
    {

        public ProductReviewMappingProfile()
        {
            CreateMap<ProductReview, ProductReviewDTO>()
                .ForMember(des => des.ProductName, opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<ProductReviewDTO, ProductReview>();


        }

    }
}
