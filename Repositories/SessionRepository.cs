using movies_api.Infrastructure.Database;
using movies_api.Models;

namespace movies_api.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly IRepository<Session> _repo;
    
    public SessionRepository(IRepository<Session> repo) 
    {
        _repo = repo;
    }

    public async Task AddAsync(Session obj)
    {
        await _repo.Create(obj);
    }

    public async Task<IEnumerable<Session>> GetAllAsync(int skip, int take)
    {
        var sessions = await _repo.GetAll();

        return sessions.Skip(skip).Take(take);
    }

    public async Task<Session?> GetByIdAsync(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task RemoveAsync(int id)
    {
        await _repo.Delete(id);
    }

    public async Task UpdateAsync(Session obj, int id)
    {
        await _repo.Update(id, obj);
    }
}