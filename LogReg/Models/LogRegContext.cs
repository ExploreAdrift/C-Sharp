#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace LogReg.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class LogRegContext : DbContext
{
    public LogRegContext(DbContextOptions options) : base(options) { }
    // the "Monsters" table name will come from the DbSet variable name
    public DbSet<User> Users { get; set; }

    public DbSet<LoginUser> loginUser { get; set; }

}