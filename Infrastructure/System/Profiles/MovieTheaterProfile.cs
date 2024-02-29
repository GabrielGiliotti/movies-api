using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class MovieTheaterProfile : Profile
{
    public MovieTheaterProfile() 
    {
        CreateMap<MovieTheaterDto, MovieTheater>();
        CreateMap<MovieTheater, MovieTheaterDto>();
        CreateMap<IEnumerable<MovieTheater>, IList<MovieTheaterDto>>();
    }
}