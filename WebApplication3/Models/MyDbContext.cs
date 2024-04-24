using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ArabaDb> Arabalar { get; set; }
    }
}
