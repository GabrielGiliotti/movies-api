namespace movies_api.DTOs;

public class SessionDto
{
    public int MovieId { get; set; }
    public virtual MovieDto? MovieDto { get; set; }
}