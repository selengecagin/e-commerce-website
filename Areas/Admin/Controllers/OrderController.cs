using e_commerce_website.Areas.Admin.Controllers;
using e_commerce_website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
  

        public IActionResult Index()
        {
            return View();
        }
    }
}



public OrderController(ApplicationDbContext db)
{

}