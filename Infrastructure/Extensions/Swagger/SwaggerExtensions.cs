using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Infrastructure.Extensions.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerSetting(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options=> options.LowercaseUrls = true);
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba tenica Inteia API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                     {
                        {
                            new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                       {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                        }
                                },
                            new string[] { }
                        }
                    });
                c.ExampleFilters();

            });
        }
    }
}
