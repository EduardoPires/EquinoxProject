using Equinox.Infra.CrossCutting.Identity.Configuration;
using Equinox.Services.Api.Configurations;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.AddApiConfiguration()                   // Api Configurations
       .AddDatabaseConfiguration()              // Setting DBContexts
       .AddApiIdentityConfiguration()           // ASP.NET Identity Settings & JWT
       .AddAutoMapperConfiguration()            // AutoMapper Settings
       .AddSwaggerConfiguration()               // Swagger Config
       .AddMediatRConfiguration()               // Adding MediatR for Domain Events and Notifications
       .AddDependencyInjectionConfiguration();  // DotNet Native DI Abstraction

var app = builder.Build();

// Configure
app.UseHttpsRedirection()
    .UseCors(c =>
    {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    })
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.UseSwaggerSetup();
app.Run();