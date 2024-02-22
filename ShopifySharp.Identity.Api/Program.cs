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




// DbContext s�n�f�n� ve ba�lant� dizesini yap�land�rma
builder.Services.AddDbContext<ShopifySharpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ITokenService hizmetinin eklenmesi (�rnek olarak)
//builder.Services.AddScoped<ITokenService, JwtTokenService>();

//// ASP.NET Core Identity'yi eklemek
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Identity ayarlar�n� burada yap�land�rabilirsiniz
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
