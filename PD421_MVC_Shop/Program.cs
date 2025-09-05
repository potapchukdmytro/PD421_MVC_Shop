using Microsoft.EntityFrameworkCore;
using PD421_MVC_Shop;
using PD421_MVC_Shop.Initializer;
using PD421_MVC_Shop.Repositories.Category;
using PD421_MVC_Shop.Repositories.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("SqlServer");
    options.UseSqlServer(connectionString);
});

// Клас існує в тільки в одному екземплярі https://refactoring.guru/uk/design-patterns/singleton
// builder.Services.AddSingleton<CategoryRepository>();

// Створює новий об'єкт щоразу коли його запитують
//builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// Створює новий об'єкт для кожного HTTP запиту
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add session
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Seed();

app.Run();