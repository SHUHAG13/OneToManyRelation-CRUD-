using AutoMapper;
using EF_Relations.Data;
using EF_Relations.Models.DTOs;

namespace EF_Relations.Mappers
{
    public class AddMapperProfile : Profile
    {
        public AddMapperProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerAddressDto, CustomerAddresses>();

        }
    }
}
