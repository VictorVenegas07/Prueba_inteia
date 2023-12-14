using Domain.Common;
using Domain.Common.Security;
using Infrastructure.Inicialize;
using Infrastructure.Repository;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
