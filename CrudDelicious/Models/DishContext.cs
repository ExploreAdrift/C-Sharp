#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CrudDelicious.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class DishContext : DbContext
{
    public DishContext(DbContextOptions options) : base(options) { }
    // the "Monsters" table name will come from the DbSet variable name
    public DbSet<Dish> Dishes { get; set; }

}