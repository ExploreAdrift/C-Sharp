#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace CatProd.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }



}