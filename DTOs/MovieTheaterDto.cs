using System.ComponentModel.DataAnnotations;
namespace movies_api.DTOs;

public class MovieTheaterDto
{
    [StringLength(90, ErrorMessage = "MovieTheater name length exceeded")]
    public string? Name { get; set; }
}