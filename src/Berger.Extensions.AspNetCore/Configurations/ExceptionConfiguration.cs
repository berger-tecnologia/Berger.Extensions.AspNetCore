using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Berger.Extensions.AspNetCore
{
    public static class ExceptionConfiguration
    {
        public static void ConfigureExceptions(this WebApplication app)
        {
            // Temporário
            app.UseDeveloperExceptionPage();

            if (app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            // Production environment
            else
            {
                //app.UseExceptionHandler("/error");
                //app.UseHsts();
            }
        }
    }
}