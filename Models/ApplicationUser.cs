using Microsoft.AspNetCore.Identity;

namespace MvcDay2Task.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }

}
