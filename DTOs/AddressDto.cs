using System.ComponentModel.DataAnnotations;

namespace movies_api.DTOs;

public class AddressDto 
{
    [Required]
    [MaxLength(200, ErrorMessage = "Movie name length exceeded")]
    public string PublicPlace { get; set; } = null!;

    public int Number { get; set; }
}