using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.Repositories.Products;
using PD421_MVC_Shop.Services;
using PD421_MVC_Shop.ViewModels;
using PD421_MVC_Shop.ViewModels.Home;
using System.Diagnostics;

namespace PD421_MVC_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IProductRepository productRepository)
        {
            _logger = logger;
            _context = context;
            _productRepository = productRepository;
        }

        public IActionResult AddToCart(int productId)
        {
            HttpContext.Session.AddToCart(productId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            HttpContext.Session.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        public IActionResult Index(string? category, int? page)
        {
            int currentPage = page ?? 1;

            var pagination = new Pagination
            {
                Page = currentPage,
                PageSize = Settings.PaginationPageSize
            };

            var products =
                !string.IsNullOrEmpty(category)
                ? _productRepository.GetByCategory(category, pagination)
                : _productRepository.GetProducts(pagination);

            var productsList = new ProductListVM
            {
                Pagination = pagination,
                Products = products
            };

            var viewModel = new HomeVM
            {
                Categories = _context.Categories,
                ProductList = productsList,
                CategoryName = category
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
