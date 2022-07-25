using Microsoft.AspNetCore.Identity;
using System;
using System.Text.Json;

namespace DutchTreat.Models
{
    public class Seeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<StoreUser> _userManager;

        public Seeder(ApplicationDbContext context, IWebHostEnvironment env, UserManager<StoreUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public async Task SeedAsync ()
        {
            _context.Database.EnsureCreated();

            StoreUser user =  await _userManager.FindByEmailAsync("test@test.test");
            if (user == null)
            {
                user = new()
                {
                    Firstname = "test", 
                    LastName = "test2", 
                    Email = "test@test.test",
                    UserName = "test"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }

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
                    User = user,
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
