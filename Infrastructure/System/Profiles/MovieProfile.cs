using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile() 
    {
        CreateMap<MovieDto, Movie>();
        CreateMap<Movie, MovieDto>()
            .ForMember(dto => dto.SessionDto, opt => opt
                .MapFrom(movieTheater => movieTheater.Session));
        CreateMap<IEnumerable<Movie>, IList<MovieDto>>();
    }
}