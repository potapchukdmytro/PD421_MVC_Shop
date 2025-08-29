using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.ViewModels.Home;

namespace PD421_MVC_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string? category)
        {
            IQueryable<Product> products = _context.Products;

            if(!string.IsNullOrEmpty(category))
            {
                category = category.Trim().ToLower();
                products = products.Where(p => p.Category != null && p.Category.Name.ToLower() == category);
            }

            var viewModel = new HomeVM
            {
                Categories = _context.Categories,
                Products = products
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
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
