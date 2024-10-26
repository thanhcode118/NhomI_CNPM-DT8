using Microsoft.AspNetCore.Identity;

namespace KOI_Competition.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
