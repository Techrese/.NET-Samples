using Microsoft.AspNetCore.Identity;

namespace DutchTreat.Models
{
    public class StoreUser : IdentityUser
    {
        public string Firstname { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
