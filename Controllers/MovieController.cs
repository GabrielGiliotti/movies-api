using Microsoft.AspNetCore.Mvc;

namespace movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie() {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetMoviesPaged([FromQuery] int skip, [FromQuery] int take) {
        // Utilizar Skip e Take de lista 
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(string id) {
        return Ok();
    }
}