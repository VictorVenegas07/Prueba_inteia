using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure.Extensions.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerSetting(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba tenica Inteia API", Version = "v1" });
                //c.examepl
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"

                });
                
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
            
            });
        }
    }
}
