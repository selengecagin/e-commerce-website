using e_commerce_website.Data;
using e_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace e_commerce_website.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var product = _db.Product.Where(i=>i.IsHome).ToList();
            ShoppingCart cart = new ShoppingCart();

            return View(product);
        }

        public IActionResult Details(int id)
        {
            var product = _db.Product.FirstOrDefault(i=>i.Id == id); // first of default - to collect only one product info
            ShoppingCart cart = new ShoppingCart()
            {
                Product = product,
                ProductId = product.Id

            };
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
