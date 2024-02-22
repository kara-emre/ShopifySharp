using Microsoft.Extensions.DependencyInjection;
using ShopifySharp.Identity.Application.Services;

namespace ShopifySharp.Identity.Application.Dependency
{
    public static class TokenDependency
    {
        public static IServiceCollection AddTokenService(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, JwtTokenService>();

            return services;
        }
    }
}
