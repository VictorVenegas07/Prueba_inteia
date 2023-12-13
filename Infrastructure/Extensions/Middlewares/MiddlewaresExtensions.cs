using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Middlewares
{
    public static class MiddlewaresExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app) =>
            app.UseMiddleware<ErrorHandlerMiddleware>();

    }
}
