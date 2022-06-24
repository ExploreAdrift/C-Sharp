#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace crudelicous.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "This is needed")]
    public string Name { get; set; }

    [Required(ErrorMessage = "This is needed")]
    public string Chef { get; set; }

    [Required(ErrorMessage = "This is needed")]
    [Range(1, 5)]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "This is needed")]
    [Range(1, 8000, ErrorMessage = "Calories must be more than 0")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "This is needed")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
