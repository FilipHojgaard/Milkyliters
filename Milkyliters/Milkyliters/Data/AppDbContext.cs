using Microsoft.EntityFrameworkCore;
using Milkyliters.Models;

namespace Milkyliters.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
    }

    public DbSet<Feeding> Feedings { get; set; }

}
