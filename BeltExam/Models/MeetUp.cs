#pragma warning disable CS8618
namespace BeltExam.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class MeetUp
{
    [Key]
    public int MeetUpId { get; set; }


    [Required(ErrorMessage = "This is Required")]
    [MinLength(2, ErrorMessage = "Must be atleast 2 characters")]
    [Display(Name = "Title: ")]
    public string Title { get; set; }

    [Required(ErrorMessage = "You need a date!")]
    [DataType(DataType.Date)]
    [Display(Name = "Date: ")]
    public DateTime Date { get; set; }


    [Required(ErrorMessage = "This is Required")]
    [Display(Name = "Duration")]
    public string Duration { get; set; }



    [Required(ErrorMessage = "You need a Description!")]
    [MinLength(5, ErrorMessage = "Must have a Description!")]
    public string Description { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // One to Many


    public int UserId { get; set; }
    public User? Creator { get; set; }
    // Need the question mark because validation wont pass


    // Many to many
    public List<Participant> Participants { get; set; } = new List<Participant>();




}

