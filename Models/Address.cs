using System.ComponentModel.DataAnnotations;

namespace movies_api.Models;

public class Address 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Address name length exceeded")]
    public string PublicPlace { get; set; } = null!;

    public int? Number { get; set; }
    
    public virtual MovieTheater? MovieTheater { get; set; }
}