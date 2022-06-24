#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace CatProd.Models;

public class Product
{
    public int? ProductId { get; set; }



    [Required(ErrorMessage = "Is Required!")]
    [MinLength(2, ErrorMessage = "Must be more than 2 characters!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Is Required!")]
    [MinLength(2, ErrorMessage = "Must be more than 2 characters!")]
    public string Description { get; set; }


    [Required(ErrorMessage = "Is Required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Must be more than 2 characters!")]
    public Decimal? Price { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Association> Associations { get; set; } = new List<Association>();
}