using Microsoft.AspNetCore.Mvc;
using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.Repositories.Category;

namespace PD421_MVC_Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.Categories;
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
        public async Task<IActionResult> Create(Category model)
        {
            bool res = await _categoryRepository.IsExistsAsync(model.Name);
            if(res)
            {
                return View();
            }

            await _categoryRepository.CreateAsync(model);
            await _categoryRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            var model = await _categoryRepository.GetByIdAsync(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category model)
        {
            bool res = await _categoryRepository.IsExistsAsync(model.Name);
            if (res)
            {
                return View();
            }

            _categoryRepository.Update(model);
            await _categoryRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            await _categoryRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
