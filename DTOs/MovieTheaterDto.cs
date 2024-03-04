using System.ComponentModel.DataAnnotations;
namespace movies_api.DTOs;

public class MovieTheaterDto
{
    [StringLength(90, ErrorMessage = "MovieTheater name length exceeded")]
    public string? Name { get; set; }
    
    public int? AddressId { get; set; }
    public virtual AddressDto? AddressDto { get; set; }
    public virtual ICollection<SessionDto>? SessionsDto { get; set; }
}