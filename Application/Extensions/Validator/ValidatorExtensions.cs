using FluentValidation;
using Infrastructure.Adapters;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            object value = services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
