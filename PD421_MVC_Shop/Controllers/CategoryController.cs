using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.Repositories.Category;
using PD421_MVC_Shop.ViewModels.Category;

namespace PD421_MVC_Shop.Controllers
{
    [Authorize(Roles = "admin")]
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
        public async Task<IActionResult> Create(CreateCategoryVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            bool res = await _categoryRepository.IsExistsAsync(viewModel.Name ?? string.Empty);

            if (res)
            {
                ModelState.AddModelError("UniqueNameError", $"Категорія '{viewModel.Name}' вже існує");
                return View(viewModel);
            }

            var model = new Category { Name = viewModel.Name };
            await _categoryRepository.CreateAsync(model);
            await _categoryRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            var model = await _categoryRepository.GetByIdAsync(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new UpdateCategoryVM
            {
                Id = model.Id,
                Name = model.Name
            };

            return View(viewModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateCategoryVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            bool res = await _categoryRepository.IsExistsAsync(viewModel.Name ?? string.Empty);
            if (res)
            {
                ModelState.AddModelError("UniqueNameError", $"Категорія '{viewModel.Name}' вже існує");
                return View(viewModel);
            }

            var model = await _categoryRepository.GetByIdAsync(viewModel.Id);
            if (model != null)
            {
                model.Name = viewModel.Name;
                _categoryRepository.Update(model);
                await _categoryRepository.SaveChangesAsync();
            }
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
