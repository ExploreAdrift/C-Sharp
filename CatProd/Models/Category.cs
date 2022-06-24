#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace CatProd.Models;

public class Category
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Is Required!")]
    [MinLength(2, ErrorMessage = "Must be more than 2 characters!")]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> Associations { get; set; } = new List<Association>();
}
