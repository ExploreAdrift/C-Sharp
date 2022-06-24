#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace ChefsDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    [Display(Name = "Name of dish")]
    public string DishName { get; set; }

    [Required]
    [Display(Name = "Number of Calories")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be larger than 0!")]
    public string Calories { get; set; }
    [
    Required]
    [Display(Name = "Description")]
    public string Description { get; set; }

    [Required]
    [Display(Name = "Tastiness")]
    public string Tastiness { get; set; }

    [Display(Name = "Chef")]
    public int ChefId { get; set; }

    public Chef? Creator { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;




}