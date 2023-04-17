using Microsoft.AspNetCore.Identity;

namespace Authentication.Models
{
    public class User : IdentityUser
    {
        public string Address { get; set; } = string.Empty;
    }
}
