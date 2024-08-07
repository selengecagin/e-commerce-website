using e_commerce_website.Data;
using e_commerce_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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


        public IActionResult Search(string q)
        {
            if (!String.IsNullOrEmpty(q))
            {
                var search = _db.Product.Where(i => i.Title.Contains(q) || i.Description.Contains(q));
                return View(search);
            }
            return View();
        }


        public IActionResult CategoryDetails(int? id)
        {
            var product = _db.Product.Where(i => i.CategoryId == id).ToList();
            ViewBag.CategoryId = id;
            return View(product);
        }


        public IActionResult Index()
        {
            var product = _db.Product.Where(i => i.IsHome).ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                var count = _db.ShoppingCart.Where(i => i.ApplicationUserId == claim.Value).ToList().Count();
                HttpContext.Session.SetInt32(Other.ssShoppingCart, count);
            }

            return View(product);
        }

        public IActionResult Details(int id)
        {
            var product = _db.Product.FirstOrDefault(i => i.Id == id); // first of default - to collect only one product info
            ShoppingCart cart = new ShoppingCart()
            {
                Product = product,
                ProductId = product.Id

            };
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart Scart)
        {
            Scart.Id = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Scart.ApplicationUserId = claim.Value;
                ShoppingCart ShopCart = _db.ShoppingCart.FirstOrDefault(
                    u => u.ApplicationUserId == Scart.ApplicationUserId && u.ProductId == Scart.ProductId);

                if (ShopCart == null)
                {
                    _db.ShoppingCart.Add(Scart);
                }
                else
                {
                    ShopCart.Count += Scart.Count;
                }

                _db.SaveChanges();
                var count = _db.ShoppingCart.Where(i => i.ApplicationUserId == Scart.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32(Other.ssShoppingCart, count);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var existingCart = _db.ShoppingCart.FirstOrDefault(e => e.ApplicationUserId == claim.Value && e.ProductId == Scart.ProductId);
                var product = _db.Product.FirstOrDefault(i => i.Id == Scart.ProductId);

                if (existingCart != null)
                {
                    existingCart.Count += 1;
                    _db.SaveChanges();
                }
                else
                {
                    ShoppingCart cart = new ShoppingCart()
                    {
                        ProductId = Scart.ProductId,
                        ApplicationUserId = claim.Value,
                        Count = Scart.Count,
                    };
                    _db.ShoppingCart.Add(cart);
                    _db.SaveChanges();
                }

                Scart.Product = product;
            }

            return View(Scart);
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