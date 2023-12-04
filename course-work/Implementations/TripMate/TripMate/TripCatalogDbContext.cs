using Microsoft.EntityFrameworkCore;
using TripMate.Entities;

namespace TripMate
{
    public class TripCatalogDbContext : DbContext
    {
        public TripCatalogDbContext()
        {
        }

        public TripCatalogDbContext(DbContextOptions<TripCatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


    }
}
