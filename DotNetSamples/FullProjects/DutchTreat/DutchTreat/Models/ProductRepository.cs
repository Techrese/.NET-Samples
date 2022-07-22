using DutchTreat.Models.Abstractions;

namespace DutchTreat.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(x => x.Category).ToList();
        }        

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(x => x.Category == category).OrderBy(x => x.Category).ToList();
        }
    }
}
