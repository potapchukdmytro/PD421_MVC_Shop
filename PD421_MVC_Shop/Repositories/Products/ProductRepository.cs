using PD421_MVC_Shop.Models;
using PD421_MVC_Shop.ViewModels;

namespace PD421_MVC_Shop.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;

        public IQueryable<Product> GetByCategory(string category, Pagination? pagination = null)
        {
            category = category.Trim().ToLower();
            var products = Products.Where(p => p.Category != null && p.Category.Name.ToLower() == category);

            products = SetPagination(products, pagination);
            return products;
        }

        public IQueryable<Product> GetProducts(Pagination? pagination = null)
        {
            var products = SetPagination(Products, pagination);
            return products;
        }

        private IQueryable<Product> SetPagination(IQueryable<Product> products, Pagination? pagination = null)
        {
            pagination = pagination ?? new Pagination();

            pagination.PageCount = (int)Math.Ceiling(products.Count() / (double)pagination.PageSize);
            pagination.Page = pagination.Page > pagination.PageCount || pagination.Page <= 0 ? 1 : pagination.Page;

            products = products.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize);
            return products;
        }
    }
}
