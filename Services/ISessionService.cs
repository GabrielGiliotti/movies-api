using movies_api.DTOs;

namespace movies_api.Services;

public interface ISessionService
{
    Task AddSessionAsync(SessionDto obj);
    Task<SessionDto?> GetSessionByIdAsync(int id);
    Task<IEnumerable<SessionDto>> GetAllSessionsAsync(int skip, int take);
    Task UpdateSessionAsync(SessionDto obj, int id);
    Task DeleteSessionAsync(int id);
}