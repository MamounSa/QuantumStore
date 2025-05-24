using AutoMapper;
using QuantumStore.DTOs;

namespace QuantumStore.Mappings
{
    public class OrderMappingProfile:Profile
    {

        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            
        }
    }

}

