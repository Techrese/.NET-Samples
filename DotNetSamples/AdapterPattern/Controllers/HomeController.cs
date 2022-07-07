using AdapterPattern.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdapterPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Debug()
        {
            _logger.LogDebug("This is a debug message!");
            return View();
        }

        public IActionResult Info()
        {
            _logger.LogInformation("This is a info message!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}