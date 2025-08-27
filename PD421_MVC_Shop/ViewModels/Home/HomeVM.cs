using PD421_MVC_Shop.Models;

namespace PD421_MVC_Shop.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Product> Products { get; set; } = [];
        public IEnumerable<Models.Category> Categories { get; set; } = [];
    }
}
