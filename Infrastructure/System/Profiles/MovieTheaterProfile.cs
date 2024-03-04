using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class MovieTheaterProfile : Profile
{
    public MovieTheaterProfile() 
    {
        CreateMap<MovieTheaterDto, MovieTheater>();
        CreateMap<MovieTheater, MovieTheaterDto>()
            .ForMember(dto => dto.AddressDto, opt => opt
                .MapFrom(movieTheater => movieTheater.Address))
            .ForMember(dto => dto.SessionsDto, opt => opt
                .MapFrom(movieTheater => movieTheater.Sessions));
        CreateMap<IEnumerable<MovieTheater>, IList<MovieTheaterDto>>();
    }
}