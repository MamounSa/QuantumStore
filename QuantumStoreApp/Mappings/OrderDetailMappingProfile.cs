using AutoMapper;

namespace QuantumStore
{
    public class OrderDetailMappingProfile:Profile
    {
        public OrderDetailMappingProfile() 
        {

            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<OrderDetailDTO, OrderDetail>();
        }
    }
}
