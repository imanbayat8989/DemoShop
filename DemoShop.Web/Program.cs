using DemoShop.Application.Implementation;
using DemoShop.Application.Interface;
using DemoShop.DataLayer.Contract;
using DemoShop.DataLayer.Entities.Account;
using DemoShop.DataLayer.Entities.Contacts;
using DemoShop.DataLayer.Repository;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
#region Config Services

builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<IContactusService, ContactusService>();
builder.Services.AddScoped<ISellerService, SellerService>();

#endregion

#region config Database

builder.Services.AddDbContext<DemoShopDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DemoShopConnection"));
});

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
	options.LoginPath = "/login";
	options.LogoutPath = "/log-out";
	options.ExpireTimeSpan = TimeSpan.FromDays(30);
});

#endregion

#region html encoder

builder.Services.AddSingleton<HtmlEncoder> (HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(

		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );
    endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
