using System.ComponentModel.DataAnnotations;

namespace movies_api.Models;

public class Movie 
{
    [Required]
    [MaxLength(90, ErrorMessage = "Movie name length exceeded")]
    public string Title { get; set; } = null!;
    
    [Required]
    [MaxLength(20, ErrorMessage = "Movie genre length exceeded")]
    public string Genre { get; set; } = null!;
    
    [Required]
    [Range(70, 600, ErrorMessage = "The length of the film must be between 70 and 600 minutes")]
    public int Duration { get; set; }
}