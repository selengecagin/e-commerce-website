using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_website.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Adress { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string ZipCode { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
