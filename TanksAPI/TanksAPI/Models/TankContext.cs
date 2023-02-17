using Microsoft.EntityFrameworkCore;

namespace TanksAPI.Models
{
    public class TankContext : DbContext
    {
            public TankContext(DbContextOptions<TankContext> options) : base(options)
            {
                Database.EnsureCreated();
            }
            public DbSet<Tank> Tanks { get; set; }
    }
}
