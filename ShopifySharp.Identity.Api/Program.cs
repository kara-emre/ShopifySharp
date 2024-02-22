using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopifySharp.Identity.Application;
using ShopifySharp.Identity.Application.Services;
using ShopifySharp.Identity.Domain.Entities;
using ShopifySharp.Identity.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// DbContext sýnýfýný ve baðlantý dizesini yapýlandýrma
builder.Services.AddDbContext<ShopifySharpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ITokenService hizmetinin eklenmesi (örnek olarak)
//builder.Services.AddScoped<ITokenService, JwtTokenService>();

//// ASP.NET Core Identity'yi eklemek
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Identity ayarlarýný burada yapýlandýrabilirsiniz
})
.AddEntityFrameworkStores<ShopifySharpDbContext>() // DbContext'i belirtin
.AddDefaultTokenProviders();

// UserManager<User> servisini eklemek
builder.Services.AddScoped<UserManager<User>>();

builder.Services.AddTransient<ITokenService, JwtTokenService>();

builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
