using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services) => services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
