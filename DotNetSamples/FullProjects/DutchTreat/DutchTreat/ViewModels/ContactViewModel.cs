using System.ComponentModel.DataAnnotations;

namespace DutchTreat.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        
        [Required] 
        public string Subject { get; set; } = default!;
        
        [Required]
        [MaxLength(250)]
        public string Message { get; set; } = default!;

        
    }
}
