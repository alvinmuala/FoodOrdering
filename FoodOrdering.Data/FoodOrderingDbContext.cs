using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Data
{
    public class FoodOrderingDbContext : DbContext
    {
        public FoodOrderingDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
