using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile() 
    {
        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();
        CreateMap<IEnumerable<Address>, IList<AddressDto>>();
    }
}