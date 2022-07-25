using System.ComponentModel.DataAnnotations;

namespace DutchTreat.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        public bool RememberMe { get; set; }
    }
}
