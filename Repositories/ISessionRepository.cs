using movies_api.Models;

namespace movies_api.Repositories;

public interface ISessionRepository
{
    Task AddAsync(Session obj);
    Task<Session?> GetByIdAsync(int id);
    Task<IEnumerable<Session>> GetAllAsync(int skip, int take);
    Task UpdateAsync(Session obj, int id);
    Task RemoveAsync(int id);
}