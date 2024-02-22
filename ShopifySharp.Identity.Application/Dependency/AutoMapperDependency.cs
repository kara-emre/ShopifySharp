using Microsoft.Extensions.DependencyInjection;

namespace ShopifySharp.Identity.Application.Dependency
{
    public static class AutoMapperDependency
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;

        }
    }
}
