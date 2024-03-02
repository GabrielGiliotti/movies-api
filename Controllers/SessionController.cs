using Microsoft.AspNetCore.Mvc;
using movies_api.DTOs;
using movies_api.Services;

namespace movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly ILogger<SessionController> _logger;
    private readonly ISessionService _sessionService;

    public SessionController(ILogger<SessionController> logger, ISessionService sessionService)
    {
        _logger = logger;
        _sessionService = sessionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddSession(SessionDto obj) 
    {
        await _sessionService.AddSessionAsync(obj);

        return StatusCode(201, obj); 
    }

    [HttpGet]
    public async Task<IActionResult> GetSessionsPaged([FromQuery] int skip = 0, [FromQuery] int take = 100) 
    {
        var sessions = await _sessionService.GetAllSessionsAsync(skip, take);
        
        return Ok(sessions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSessionById(int id) 
    {
        var session = await _sessionService.GetSessionByIdAsync(id);
        
        return Ok(session);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSession(int id, [FromBody] SessionDto obj) 
    {
        await _sessionService.UpdateSessionAsync(obj, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id) 
    {
        await _sessionService.DeleteSessionAsync(id);

        return NoContent();
    }
}