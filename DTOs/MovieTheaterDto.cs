using System.ComponentModel.DataAnnotations;
namespace movies_api.DTOs;

public class MovieTheaterDto
{
    [StringLength(90, ErrorMessage = "MovieTheater name length exceeded")]
    public string? Name { get; set; }
    public int? AddressId { get; set; }
    public AddressDto? AddressDto { get; set; }
}