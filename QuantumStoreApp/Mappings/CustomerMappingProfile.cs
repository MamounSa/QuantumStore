using AutoMapper;
using QuantumStore.DTOs;

namespace QuantumStore
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer,CustomerDTO>();
            CreateMap<CustomerDTO,Customer>();
        }
    }
}
