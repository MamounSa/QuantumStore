using AutoMapper;
using QuantumStore.DTOs;
using QuantumStore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuantumStore
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // تجاهل ID لأنه يتم إنشاؤه تلقائيًا
            .ForMember(dest => dest.ProductCategory, opt => opt.Ignore()) // تجاهل العلاقات
            .ForMember(dest => dest.Discount, opt => opt.Ignore()) // الخصومات تُدار بشكل منفصل
            .ForMember(dest => dest.InventoryRecords, opt => opt.Ignore()); // سجلات المخزون تُدار لاحقًا


            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name)) // تضمين اسم الفئة
                .ForMember(dest => dest.DiscountRate, opt => opt.MapFrom(src => src.Discount.DiscountAmount)) // تضمين معدل الخصم
                .ForMember(dest => dest.TotalInventoryQuantity, opt => opt.MapFrom(src => src.InventoryRecords.Sum(i => i.Quantity))); // حساب إجمالي الكمية في المخزون


        }
    }
  
    


}
