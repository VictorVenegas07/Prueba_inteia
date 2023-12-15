using Infrastructure.Extensions.Cors;
using Infrastructure.Extensions.Jwt;
using Infrastructure.Extensions.Middlewares;
using Infrastructure.Extensions.Persistence;
using Infrastructure.Extensions.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddCorsPolicy(configuration)
                .AddJwtSetting(configuration)
                .AddSwaggerSetting()
                .AddContextDataBase(configuration)
                .AddPersistenceServices();
        }
        public static void UsePersistenceInfraestructure(this IApplicationBuilder builder)
        {
            builder
                .UseCorsPolicy()
                .UseMiddlewares();
        }
    }
}
