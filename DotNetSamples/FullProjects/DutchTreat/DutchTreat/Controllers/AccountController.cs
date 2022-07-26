using DutchTreat.Models;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DutchTreat.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<StoreUser> _signManager;
        private readonly UserManager<StoreUser> _userManager;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<StoreUser> signInManager, UserManager<StoreUser> userManager, IConfiguration configuration)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _config = configuration;
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

            return View("Login");
            
        }

        public async Task<IActionResult> LogOut()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Token:key").Value));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.RsaPKCS1);
                        var token = new JwtSecurityToken(_config.GetSection("Token.Issuer").Value, _config.GetSection("Token.Audience").Value, claims, null, DateTime.Now.AddMinutes(20), credentials);
                                                
                        return Created("", new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
                    }
                }                
            }

            return BadRequest();
        }
    }
}
