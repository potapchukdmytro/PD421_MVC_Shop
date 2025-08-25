namespace PD421_MVC_Shop.Repositories.Category
{
    public interface ICategoryRepository
    {
        IQueryable<Models.Category> Categories { get; }
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task CreateAsync(Models.Category model);
        void Update(Models.Category model);
        Task<Models.Category?> GetByIdAsync(int id);
        Task<Models.Category?> GetByNameAsync(string name);
        Task<bool> IsExistsAsync(string name);
    }
}