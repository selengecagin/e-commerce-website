using Microsoft.AspNetCore.Identity;

namespace e_commerce_website.Models
{
    public class AppplicationUser:IdentityUser
    {
        public int MyProperty { get; set; }


    }
}
