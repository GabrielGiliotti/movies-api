using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile() 
    {
        CreateMap<MovieDto, Movie>();
        CreateMap<Movie, MovieDto>();
        CreateMap<IEnumerable<Movie>, IEnumerable<MovieDto>>();
    }
}