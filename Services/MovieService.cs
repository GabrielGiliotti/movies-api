using movies_api.Models;
using movies_api.Repositories;

namespace movies_api.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    
    public MovieService(IMovieRepository repository) 
    {
        _repository = repository;
    }

    public async Task AddMovieAsync(Movie obj)
    {
        await _repository.AddAsync(obj);
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync(int skip, int take)
    {
        return await _repository.GetAllAsync(skip, take);
    }

    public async Task<Movie?> GetMovieByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}