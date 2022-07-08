using Microsoft.EntityFrameworkCore;
namespace RepositoryPattern_Example2
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext()
            :base()
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
