using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopifySharp.Identity.Domain.Entities;
using ShopifySharp.Identity.Infrastructure.Context;

namespace ShopifySharp.Identity.Application.Dependency
{
    public static class DBContextDependency
    {
        public static IServiceCollection AddShopifySharpIdentityDbContext(this IServiceCollection services,string connectionString)
        {

            // DbContext sınıfını ve bağlantı dizesini yapılandırma
            services.AddDbContext<ShopifySharpIdentityDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password = new()
                {
                    RequireDigit = false,
                    RequiredLength = 5,
                    RequiredUniqueChars = 0,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false
                };

                // Identity ayarlarını burada yapılandırabilirsiniz
            })
            .AddEntityFrameworkStores<ShopifySharpIdentityDbContext>() // DbContext'i belirtin
            .AddDefaultTokenProviders();


            return services;
        }
    }
}
