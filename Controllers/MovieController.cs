using Microsoft.AspNetCore.Mvc;
using movies_api.Models;
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
    public async Task<IActionResult> AddMovie(Movie obj) 
    {
        await _movieService.AddMovieAsync(obj);

        return CreatedAtAction(nameof(GetMovieById), new { id = obj.Id }, obj);
    }

    [HttpGet]
    public async Task<IActionResult> GetMoviesPaged([FromQuery] int skip = 0, [FromQuery] int take = 100) 
    {
        var movies = await _movieService.GetAllMoviesAsync(skip, take);
        
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id) 
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        
        return Ok(movie);
    }
}