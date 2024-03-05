using movies_api.DTOs;

namespace movies_api.Services;

public interface IMovieService
{
    Task AddMovieAsync(MovieDto obj);
    Task<MovieDto?> GetMovieByIdAsync(int id);
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync(int skip, int take, string? theaterName);
    Task UpdateMovieAsync(MovieDto obj, int id);
    Task DeleteMovieAsync(int id);
}