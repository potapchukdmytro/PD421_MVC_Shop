using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.ViewModels;

namespace PD421_MVC_Shop.Repositories.Products
{
    public interface IProductRepository
    {
        public IQueryable<Product> Products { get; }
        public IQueryable<Product> GetByCategory(string category, Pagination? pagination = null);
        public IQueryable<Product> GetProducts(Pagination? pagination = null);
    }
}
