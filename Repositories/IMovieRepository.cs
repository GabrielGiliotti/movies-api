using movies_api.Models;

namespace movies_api.Repositories;

public interface IMovieRepository
{
    Task AddAsync(Movie obj);
    Task<Movie?> GetByIdAsync(int id);
    Task<IEnumerable<Movie>> GetAllAsync(int skip, int take, string? theaterName);
    Task UpdateAsync(Movie obj, int id);
    Task RemoveAsync(int id);
}