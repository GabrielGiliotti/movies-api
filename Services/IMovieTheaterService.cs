using movies_api.DTOs;

namespace movies_api.Services;

public interface IMovieTheaterService
{
    Task AddMovieTheaterAsync(MovieTheaterDto obj);
    Task<MovieTheaterDto?> GetMovieTheaterByIdAsync(int id);
    Task<IEnumerable<MovieTheaterDto>> GetAllMovieTheatersAsync(int skip, int take);
    Task UpdateMovieTheaterAsync(MovieTheaterDto obj, int id);
    Task DeleteMovieTheaterAsync(int id);
}