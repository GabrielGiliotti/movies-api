using Microsoft.AspNetCore.Mvc;
using movies_api.DTOs;
using movies_api.Services;

namespace movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieService _movieService;

    public MovieController(ILogger<MovieController> logger, IMovieService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie(MovieDto obj) 
    {
        await _movieService.AddMovieAsync(obj);

        return StatusCode(201, obj); 
    }

    [HttpGet]
    public async Task<IActionResult> GetMoviesPaged([FromQuery] int skip = 0, [FromQuery] int take = 100, [FromQuery] string? theaterName = null) 
    {
        var movies = await _movieService.GetAllMoviesAsync(skip, take, theaterName);
        
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id) 
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        
        return Ok(movie);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto obj) 
    {
        await _movieService.UpdateMovieAsync(obj, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id) 
    {
        await _movieService.DeleteMovieAsync(id);

        return NoContent();
    }
}