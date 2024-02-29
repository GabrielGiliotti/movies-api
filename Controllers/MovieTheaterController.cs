using Microsoft.AspNetCore.Mvc;
using movies_api.DTOs;
using movies_api.Services;

namespace movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private readonly ILogger<MovieTheaterController> _logger;
    private readonly IMovieTheaterService _movieTheaterService;

    public MovieTheaterController(ILogger<MovieTheaterController> logger, IMovieTheaterService movieTheaterService)
    {
        _logger = logger;
        _movieTheaterService = movieTheaterService;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovieTheater(MovieTheaterDto obj) 
    {
        await _movieTheaterService.AddMovieTheaterAsync(obj);

        return StatusCode(201, obj); 
    }

    [HttpGet]
    public async Task<IActionResult> GetMovieTheatersPaged([FromQuery] int skip = 0, [FromQuery] int take = 100) 
    {
        var movies = await _movieTheaterService.GetAllMovieTheatersAsync(skip, take);
        
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieTheaterById(int id) 
    {
        var movie = await _movieTheaterService.GetMovieTheaterByIdAsync(id);
        
        return Ok(movie);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateMovieTheater(int id, [FromBody] MovieTheaterDto obj) 
    {
        await _movieTheaterService.UpdateMovieTheaterAsync(obj, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovieTheater(int id) 
    {
        await _movieTheaterService.DeleteMovieTheaterAsync(id);

        return NoContent();
    }
}