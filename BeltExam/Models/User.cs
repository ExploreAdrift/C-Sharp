#pragma warning disable CS8618
namespace BeltExam.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
public class User
{
    [Key]
    public int UserId { get; set; }


    [Required(ErrorMessage = "This is Required")]
    [MinLength(2, ErrorMessage = "Must be atleast 2 characters")]
    [Display(Name = "Name:")]
    public string Name { get; set; }


    [Required(ErrorMessage = "You need an Email!")]
    [Display(Name = "Email: ")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "You need a Password!")]
    [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords don't match!")]
    public string Confirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    // One to Many
    public List<MeetUp> MeetUps { get; set; } = new List<MeetUp>();

    // Many to Many
    public List<Participant> Participants { get; set; } = new List<Participant>();



}

