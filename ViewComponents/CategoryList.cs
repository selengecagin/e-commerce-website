using e_commerce_website.Data;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_website.ViewComponents
{
    public class CategoryList : ViewComponent
    {

        private readonly ApplicationDbContext _db;
        public CategoryList(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var category = _db.Categories.ToList();
            return View(category);  
        }
    }
}
