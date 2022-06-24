using System.ComponentModel.DataAnnotations;
namespace practicetwo.Models;

public class ResultsSubmit
{
    [Display(Name = "FirstName")]
    [Required]

    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName")]
    [Required]

    public string LastName { get; set; } = null!;


    [Display(Name = "Age")]
    [Required]
    public int Age { get; set; }


    [Display(Name = "Email")]
    [Required]
    [EmailAddress]
    public string? Email { get; set; }


    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string? Password { get; set; }
}

