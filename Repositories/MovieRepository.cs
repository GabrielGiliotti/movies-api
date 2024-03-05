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

    public async Task<IEnumerable<Movie>> GetAllAsync(int skip, int take, string? theaterName)
    {
        var movies = await _repo.GetAll();

        if(theaterName == null)
            return movies.Skip(skip).Take(take);

        return movies.Where(m => m.Sessions != null && m.Sessions.Any(s => s.MovieTheater != null && s.MovieTheater.Name == theaterName));
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