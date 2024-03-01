using System.ComponentModel.DataAnnotations;

namespace movies_api.Models;

public class MovieTheater 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(90, ErrorMessage = "MovieTheater name length exceeded")]
    public string Name { get; set; } = null!;

    public int? AddressId { get; set; }
    public virtual Address? Address { get; set; }
}