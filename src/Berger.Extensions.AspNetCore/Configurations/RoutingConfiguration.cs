using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.AspNetCore
{
    public static class RoutingConfiguration
    {
        public static IServiceCollection ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            return services;
        }
    }
}