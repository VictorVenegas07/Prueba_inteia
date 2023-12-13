using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Cors
{
    public static class CoreExtensions
    {
        private const string CorsPolicy = "Cors";
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.GetSection("Cors").Get<CoreSettings>();

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,builder =>
                {
                    builder.WithOrigins(corsSettings.Origin)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            return services;
        }
        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder builder)
        {
            builder.UseCors(CorsPolicy);
            return builder;
        }
    }
}
