using Microsoft.Extensions.DependencyInjection;

namespace ShopifySharp.Identity.Application.Dependency
{
    public static class MediatRDependency
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;

        }
    }
}
