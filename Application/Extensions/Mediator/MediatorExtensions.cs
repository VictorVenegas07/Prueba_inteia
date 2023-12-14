using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions.Mediator
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services) => services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
