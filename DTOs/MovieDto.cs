using System.ComponentModel.DataAnnotations;
namespace movies_api.DTOs;

public class MovieDto
{
    [StringLength(90, ErrorMessage = "Movie name length exceeded")]
    public string? Title { get; set; }

    [StringLength(86, ErrorMessage = "Movie director length exceeded")]
    public string? Director { get; set; } 
    
    [StringLength(50, ErrorMessage = "Movie genre length exceeded")]
    public string? Genre { get; set; }
    
    [Range(70, 600, ErrorMessage = "The length of the film must be between 70 and 600 minutes")]
    public int? Duration { get; set; }

    public virtual ICollection<SessionDto>? Sessions { get; set; }
}