using DutchTreat.Models;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<StoreUser> _signManager;

        public AccountController(SignInManager<StoreUser> signInManager)
        {
            _signManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public async Task<IActionResult> SignUp(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Shop","Home");
                }
            }

            return View();
            
        }


        public async Task<IActionResult> LogOut()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
