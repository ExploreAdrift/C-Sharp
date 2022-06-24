#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WeddingPlanner.Models;

public class Rsvp
{
    [Key]
    public int RsvpId { get; set; }

    public User? user { get; set; }
    public int UserId { get; set; }
    public Wedding? wedding { get; set; }
    public int WeddingId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



}