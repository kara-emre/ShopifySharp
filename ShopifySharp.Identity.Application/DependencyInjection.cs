using Microsoft.Extensions.DependencyInjection;

namespace ShopifySharp.Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;

        }
    }
}
