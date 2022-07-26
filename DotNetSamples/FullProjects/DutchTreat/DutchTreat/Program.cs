using DutchTreat.Models;
using DutchTreat.Models.Abstractions;
using DutchTreat.Services;
using DutchTreat.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddTransient<Seeder>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAuthentication()
    .AddCookie()
    .AddJwtBearer(config => 
    {
        config.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = builder.Configuration.GetSection("Tokens.Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("Tokens.Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Tokesn.key").Value))
        };
    });

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddIdentity<StoreUser, IdentityRole>(config => 
{
    config.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();        

builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var scopefactory = app.Services.GetService<IServiceScopeFactory>();
//using (var scope = scopefactory.CreateScope())
//{
//    var seeder = app.Services.GetService<Seeder>();
//    await seeder.SeedAsync();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
