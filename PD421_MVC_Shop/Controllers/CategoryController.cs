using Microsoft.AspNetCore.Mvc;
using PD421_MVC_Shop.Models;

namespace PD421_MVC_Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;

            return View(categories);
        }
    }
}
