using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.AspNetCore
{
    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services, string name, string[] origins)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(name: name,
                    policy =>
                    {
                        policy.WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }
    }
}