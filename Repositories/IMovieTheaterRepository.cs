using movies_api.Models;

namespace movies_api.Repositories;

public interface IMovieTheaterRepository
{
    Task AddAsync(MovieTheater obj);
    Task<MovieTheater?> GetByIdAsync(int id);
    Task<IEnumerable<MovieTheater>> GetAllAsync(int skip, int take, int? addressId);
    Task UpdateAsync(MovieTheater obj, int id);
    Task RemoveAsync(int id);
}