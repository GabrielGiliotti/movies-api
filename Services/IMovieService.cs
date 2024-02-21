using movies_api.Models;

namespace movies_api.Services;

public interface IMovieService
{
    Task AddMovieAsync(Movie obj);
    Task<Movie?> GetMovieByIdAsync(int id);
    Task<IEnumerable<Movie>> GetAllMoviesAsync(int skip, int take);
}