﻿using Microsoft.AspNetCore.Routing;
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
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            services.Configure<RouteOptions>(options=> options.LowercaseUrls = true);
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Prueba tenica Inteia API",
                    Version = "v1",
                    Description = "API para gestionar proveedores",
                    Contact = new OpenApiContact
                    {
                        Name = "Victor Venegas",
                        Email = "victorvenegas07@email.com",
                        Url = new Uri("https://github.com/VictorVenegas07"),
                    },
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"

                });
                var xmlFile = $"Api.xml";
                
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
