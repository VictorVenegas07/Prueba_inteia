using Application.Extensions;
using Domain.Common.Security;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Infrastructure.Inicialize;
using Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceApplication();
builder.Services.AddPersistenceInfraestructure(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba tenica Inteia API");
    });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Obtener configuración de MongoDB
    var mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    var passwordHasher = services.GetRequiredService<IPasswordHasher>();
    var connectionString = mongoDbSettings.ConnectionString;
    var databaseName = mongoDbSettings.DatabaseName;

    // Crear e inicializar DataSeeder
    var dataSeeder = new DataSeeder(connectionString, databaseName, passwordHasher);
    dataSeeder.SeedData();
}

app.UsePersistenceInfraestructure();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
