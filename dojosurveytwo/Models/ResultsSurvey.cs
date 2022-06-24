using System.ComponentModel.DataAnnotations;
namespace dojosurveytwo.Models;

public class ResultsSurvey
{
    [Display(Name = "Name")]
    [Required]
    [MinLength(3, ErrorMessage = "Must beat least 3 characters")]
    public string Name { get; set; } = null!;

    [Display(Name = "Location")]
    [Required]
    [MinLength(3)]
    public string Location { get; set; } = null!;

    [Display(Name = "Language")]
    [Required]

    public string Language { get; set; } = null!;

    [Display(Name = "Comment")]
    [MinLength(20)]
    public string? Comment { get; set; }


    // [Required(ErrorMessage ="You need a password")]
    // [MinLength(3, ErrorMessage = "Must beat least 3 characters")]
    // [Compare("Password)]
    // [DataType()]
}

