using System.ComponentModel.DataAnnotations;

namespace movies_api.Models;

public class Address 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Movie name length exceeded")]
    public string PublicPlace { get; set; } = null!;

    public int? Number { get; set; }
}