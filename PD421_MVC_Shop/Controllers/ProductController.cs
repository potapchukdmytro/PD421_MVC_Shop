using Microsoft.AspNetCore.Mvc;
using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.ViewModels.Product;
using System.Text;

namespace PD421_MVC_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        private string? SaveImage(IFormFile? image)
        {
            if (image == null)
            {
                return null;
            }

            // "image/webp"
            string[] types = image.ContentType.Split('/');

            if(types.Length != 2 || types[0] != "image")
            {
                return null;
            }

            string imageName = $"{Guid.NewGuid().ToString()}.{types[1]}";
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", imageName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                using (var imageStream = image.OpenReadStream())
                {
                    imageStream.CopyTo(stream);
                }
            }

            return imageName;
        }

        public IActionResult Index()
        {
            var products = _context.Products;
            return View(products);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProductVM
            {
                Categories = _context.Categories
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // FromForm для multipart/form-data
        public IActionResult Create([FromForm] CreateProductVM viewModel)
        {
            var model = new Product
            {
                CategoryId = viewModel.CategoryId,
                Name = viewModel.Name ?? string.Empty,
                Description = viewModel.Description,
                Count = viewModel.Count,
                Price = viewModel.Price,
                Image = SaveImage(viewModel.Image)
            };

            _context.Products.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
