using e_commerce_website.Data;
using e_commerce_website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_website.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(UserManager<IdentityUser> userManager,
            IEmailSender emailSender,
            ApplicationDbContext db
            )
        {
            _db = db;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
