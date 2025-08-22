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

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Для захисту від CSRF атак
        public IActionResult Create(Category model)
        {
            bool res = _context.Categories.Any(c => c.Name.ToLower() == model.Name.ToLower());
            if(res)
            {
                return View();
            }

            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Update(int id)
        {
            var model = _context.Categories.Find(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category model)
        {
            bool res = _context.Categories.Any(c => c.Name.ToLower() == model.Name.ToLower());
            if (res)
            {
                return View();
            }

            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Delete(int id)
        {
            var model = _context.Categories.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            _context.Categories.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
