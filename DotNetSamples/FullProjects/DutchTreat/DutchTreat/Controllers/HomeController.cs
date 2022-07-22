using DutchTreat.Models;
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

        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}