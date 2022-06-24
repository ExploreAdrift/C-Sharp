#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }


    [Required(ErrorMessage = "This is Required")]
    [MinLength(2, ErrorMessage = "Must be atleast 2 characters")]
    [Display(Name = "Wedder One:")]
    public string WedderOne { get; set; }


    [Required(ErrorMessage = "This is Required")]
    [MinLength(2, ErrorMessage = "Must be atleast 2 characters")]
    [Display(Name = "Wedder Two:")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage = "You need a date!")]
    [DataType(DataType.Date)]
    [Display(Name = "Date: ")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "You need an Address!")]
    [MinLength(5, ErrorMessage = "Must be a valid address!")]
    public string Address { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // One to Many

    public Wedding? Creator { get; set; }
    // Need the question mark because validation wont pass
    public int UserId { get; set; }

    // Many to many
    public List<Rsvp> Rsvps { get; set; } = new List<Rsvp>();




}

