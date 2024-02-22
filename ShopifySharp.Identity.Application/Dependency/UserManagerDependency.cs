using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopifySharp.Identity.Domain.Entities;

namespace ShopifySharp.Identity.Application.Dependency
{
    public static class UserManagerDependency
    {
        public static IServiceCollection AddUserManager(this IServiceCollection services)
        {
            services.AddScoped<UserManager<User>>();
            
            return services;
        }
    }
}
