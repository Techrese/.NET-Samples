using DutchTreat.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }        

        public void AddEntity(object order)
        {
            _context.Add(order);
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
                return _context.Orders.Where(x => x.User.UserName == username).Include(x => x.Items).ThenInclude(x => x.Product).ToList();

            return _context.Orders.Where(x => x.User.UserName == username).ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(x => x.Category).ToList();
        }

        public Order GetOrderById(string username, Guid id)
        {
            return _context.Orders.Where(x => x.User.UserName == username).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(x => x.Category == category).OrderBy(x => x.Category).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
