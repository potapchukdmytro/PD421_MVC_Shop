namespace PD421_MVC_Shop.ViewModels.Home
{
    public class HomeVM
    {
        public ProductListVM ProductList { get; set; } = new();
        public IEnumerable<Models.Category> Categories { get; set; } = [];
        public string? CategoryName { get; set; }
    }
}
