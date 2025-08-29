namespace PD421_MVC_Shop.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Models.Product> Products { get; set; } = [];
        public IEnumerable<Models.Category> Categories { get; set; } = [];
    }
}
