#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace BeltExam.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class BeltContext : DbContext
{
    public BeltContext(DbContextOptions options) : base(options) { }
    // the "Monsters" table name will come from the DbSet variable name


    // One to Many(Build and Update database)
    public DbSet<User> Users { get; set; }
    public DbSet<MeetUp> MeetUps { get; set; }


    // // Many to Many
    public DbSet<Participant> Participants { get; set; }

}