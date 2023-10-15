using DemoShop.Application.Implementation;
using DemoShop.Application.Interface;
using DemoShop.DataLayer.Contract;
using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserService, UserService>();

#region
builder.Services.AddDbContext<DemoShopDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DemoShopConnection"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
