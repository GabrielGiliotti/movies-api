using movies_api.Infrastructure.Database;
using movies_api.Models;

namespace movies_api.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IRepository<Movie> _repo;
    
    public MovieRepository(IRepository<Movie> repo) 
    {
        _repo = repo;
    }

    public async Task AddAsync(Movie obj)
    {
        await _repo.Create(obj);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _repo.GetAll();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task RemoveAsync(int id)
    {
        await _repo.Delete(id);
    }

    public async Task UpdateAsync(Movie obj, int id)
    {
        await _repo.Update(id, obj);
    }
}