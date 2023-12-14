using Application.Extensions.Mapper;
using Application.Extensions.Mediator;
using Application.Extensions.Services;
using Application.Extensions.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceApplication(this IServiceCollection services)
        {
            services
                .AddMediator()
                .AddMapper()
                .AddValidation()
                .AddServices();
        }
    }
}
