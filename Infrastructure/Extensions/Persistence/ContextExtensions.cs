using Domain.Context;
using Domain.Settings;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Extensions.Persistence
{
    public static class ContextExtensions
    {
        public static IServiceCollection AddContextDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(typeof(MongoDbSettings).Name));
            services.AddSingleton<MongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            return services;
        }
    }
}
