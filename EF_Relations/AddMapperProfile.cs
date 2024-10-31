using AutoMapper;
using EF_Relations.Data;

namespace EF_Relations
{
    public class AddMapperProfile:Profile
    {
        public AddMapperProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerAddressDto, CustomerAddresses>();

        }
    }
}
