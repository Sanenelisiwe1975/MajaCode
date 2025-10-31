using Microsoft.EntityFrameworkCore;
using NeighborhoodAPI.Models;

namespace NeighborhoodAPI.Data
{
    public class NeighborhoodDbContext : DbContext
    {
        public NeighborhoodDbContext(DbContextOptions<NeighborhoodDbContext> options)
            : base(options) { }

        public DbSet<Neighborhood> Neighborhoods { get; set; }
    }
}
