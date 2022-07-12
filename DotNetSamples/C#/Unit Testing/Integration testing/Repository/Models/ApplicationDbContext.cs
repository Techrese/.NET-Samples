using Microsoft.EntityFrameworkCore;

namespace Repository.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
