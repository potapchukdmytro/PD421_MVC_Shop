using Microsoft.EntityFrameworkCore;
using PD421_MVC_Shop.Models;

namespace PD421_MVC_Shop
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Зв'язок одиного до багатьох між категоріями та продуктами
            // Якщо категорія видаляється, то всі продукти в цій категорії також видаляються
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
