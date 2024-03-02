using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;
using movies_api.Repositories;

namespace movies_api.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _repository;
    private readonly IMapper _mapper;
    
    public SessionService(IMapper mapper, ISessionRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task AddSessionAsync(SessionDto dto)
    {
        var session = _mapper.Map<Session>(dto);

        if(session != null)
            await _repository.AddAsync(session);
        else
            throw new Exception("Error when adding Session");
    }

    public async Task<IEnumerable<SessionDto>> GetAllSessionsAsync(int skip, int take)
    {
        var sessions = await _repository.GetAllAsync(skip, take);
        
        var list = _mapper.Map<IEnumerable<SessionDto>>(sessions);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping Session List");
    }

    public async Task<SessionDto?> GetSessionByIdAsync(int id)
    {
        var session = await _repository.GetByIdAsync(id);

        var dto = _mapper.Map<SessionDto>(session);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping SessionDto");
    }

    public async Task UpdateSessionAsync(SessionDto obj, int id)
    {
        var toUpdate = await _repository.GetByIdAsync(id) ?? throw new Exception("Session not found");

        await _repository.UpdateAsync(toUpdate, id);
    }

    public async Task DeleteSessionAsync(int id) 
    {
        var session = await _repository.GetByIdAsync(id);

        if(session == null)
            throw new Exception("Session not found");

        await _repository.RemoveAsync(id);
    }
}