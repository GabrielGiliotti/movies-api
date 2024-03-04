namespace movies_api.DTOs;

public class SessionDto
{    
    public int? MovieId { get; set; }
    public int? MovieTheaterId { get; set; }
    public virtual MovieDto? MovieDto { get; set; }
    public virtual MovieTheaterDto? MovieTheaterDto { get; set; }
}