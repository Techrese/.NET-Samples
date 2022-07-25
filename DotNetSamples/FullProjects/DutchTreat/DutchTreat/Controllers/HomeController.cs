using DutchTreat.Models;
using DutchTreat.Models.Abstractions;
using DutchTreat.Services.Abstractions;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DutchTreat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IMailService mailService, ApplicationDbContext context, IProductRepository productRepository)
        {
            _logger = logger;
            _mailService = mailService;
            _context = context;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }

        public IActionResult ContactSave(ContactViewModel contactviewmodel)
        {
            if (ModelState.IsValid)
            {
                _mailService.Send("you", "mail", "you got mail.");
                ViewData["UserMessage"] = "Mail send";
                ModelState.Clear();
            }
            return RedirectToAction("Contact");
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _productRepository.GetAllProducts();
            return View(results);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}