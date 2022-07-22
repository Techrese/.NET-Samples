using System;
using System.Text.Json;

namespace DutchTreat.Models
{
    public class Seeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public Seeder(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                await _context.Products.AddRangeAsync(products);

                Order order = new()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",
                    Id = Guid.NewGuid(),
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price,
                            Id = Guid.NewGuid(),
                        }
                    }
                };

                await _context.AddAsync(order);


                await _context.SaveChangesAsync();
            }
            
        }
    }
}
