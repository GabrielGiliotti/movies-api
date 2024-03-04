using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile() 
    {
        CreateMap<SessionDto, Session>();
        CreateMap<Session, SessionDto>()
            .ForMember(dto => dto.MovieDto, opt => opt
                .MapFrom(movieTheater => movieTheater.Movie))
            .ForMember(dto => dto.MovieTheaterDto, opt => opt
                .MapFrom(movie => movie.MovieTheater));
        CreateMap<IEnumerable<Session>, IList<SessionDto>>();
    }
}