#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace crud.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "This is needed")]
    [MinLength(2, ErrorMessage = "Name must be atleast 2 letters")]
    [Display(Name = "First name")]
    public int FirstName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
