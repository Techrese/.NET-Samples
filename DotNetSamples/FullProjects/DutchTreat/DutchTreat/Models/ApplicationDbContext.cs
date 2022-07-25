using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Models
{
    public class ApplicationDbContext : IdentityDbContext<StoreUser>
    {
        public ApplicationDbContext(DbContextOptions options) 
            :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
