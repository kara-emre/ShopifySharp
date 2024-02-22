using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopifySharp.Product.Infrastructure.Context;

namespace ShopifySharp.Product.Application.Dependency
{
    public static class DBContextDependency
    {
        public static IServiceCollection AddShopifySharpProductDbContext(this IServiceCollection services,string connectionString)
        {

            // DbContext sınıfını ve bağlantı dizesini yapılandırma
            services.AddDbContext<ShopifySharpProductDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
