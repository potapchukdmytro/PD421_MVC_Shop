using Microsoft.AspNetCore.Mvc;

namespace PD421_MVC_Shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
