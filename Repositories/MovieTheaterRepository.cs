using movies_api.Infrastructure.Database;
using movies_api.Models;

namespace movies_api.Repositories;

public class MovieTheaterRepository : IMovieTheaterRepository
{
    private readonly IRepository<MovieTheater> _repo;
    
    public MovieTheaterRepository(IRepository<MovieTheater> repo) 
    {
        _repo = repo;
    }

    public async Task AddAsync(MovieTheater obj)
    {
        await _repo.Create(obj);
    }

    public async Task<IEnumerable<MovieTheater>> GetAllAsync(int skip, int take)
    {
        var movies = await _repo.GetAll();

        return movies.Skip(skip).Take(take);
    }

    public async Task<MovieTheater?> GetByIdAsync(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task RemoveAsync(int id)
    {
        await _repo.Delete(id);
    }

    public async Task UpdateAsync(MovieTheater obj, int id)
    {
        await _repo.Update(id, obj);
    }
}