using Microsoft.EntityFrameworkCore;

namespace PD421_MVC_Shop.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Category> Categories => _context.Categories;

        public async Task CreateAsync(Models.Category model)
        {
            await _context.Categories.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _context.Categories.FindAsync(id);
            if (model != null)
            {
                _context.Remove(model);
            }
        }

        public async Task<Models.Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Models.Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> IsExistsAsync(string name)
        {
            return await _context.Categories
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Models.Category model)
        {
            _context.Categories.Update(model);
        }
    }
}
