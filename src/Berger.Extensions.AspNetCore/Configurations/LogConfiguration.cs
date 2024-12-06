using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.AspNetCore
{
    public static class LogConfiguration
    {
        public static IServiceCollection ConfigureLog(this IServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });

            return services;
        }
        public static ILogger<T> GetLogger<T>(this IServiceProvider services)
        {
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            return loggerFactory.CreateLogger<T>();
        }
    }
}