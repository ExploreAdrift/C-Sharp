#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace ChefsDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [
    Required]
    [Display(Name = "When were you born?")]
    public DateTime Birthday { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> MadeDish { get; set; } = new List<Dish>();
}