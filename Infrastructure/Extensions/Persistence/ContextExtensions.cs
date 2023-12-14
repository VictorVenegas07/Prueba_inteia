using Infrastructure.Context;
using Infrastructure.Inicialize;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Persistence
{
    public static class ContextExtensions
    {
        public static IServiceCollection AddContextDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(typeof(MongoDbSettings).Name));
            //services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddSingleton<MongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            return services;
        }
    }
}
