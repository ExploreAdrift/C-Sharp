#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace BeltExam.Models;

public class Participant
{
    [Key]
    public int ParticipantId { get; set; }

    public User? User { get; set; }
    public int UserId { get; set; }
    public int MeetUpId { get; set; }
    public MeetUp? Meetup { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



}