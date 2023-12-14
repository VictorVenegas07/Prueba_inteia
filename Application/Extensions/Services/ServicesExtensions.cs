using Application.Services;
using Domain.Common;
using Domain.Common.Security;
using Domain.Entities;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ProviderService>();
            services.AddTransient<AuthService>();
            services.AddTransient<UserService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
