using Microsoft.EntityFrameworkCore;
using WebAPICars.Models;

namespace WebAPICars.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
