using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.AspNetCore
{
    public static class RazorConfiguration
    {
        public static IServiceCollection ConfigureViewEngine(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
            });

            return services;
        }
    }
}