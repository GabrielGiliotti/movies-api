using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;

namespace movies_api.Infrastructure.System.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile() 
    {
        CreateMap<SessionDto, Session>();
        CreateMap<Session, SessionDto>();
        CreateMap<IEnumerable<Session>, IList<SessionDto>>();
    }
}