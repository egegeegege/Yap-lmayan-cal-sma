using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class MeyveDbContext : DbContext
    {
        public MeyveDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MeyveDb> MyProperty { get; set; }
    }
}
