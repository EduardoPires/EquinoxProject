using Equinox.Infra.CrossCutting.Identity;
using Equinox.UI.Web.Configurations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity;
using NetDevPack.Identity.User;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// ConfigureServices

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});
builder.Services.AddRazorPages();

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// ASP.NET Identity Settings
builder.Services.AddWebAppIdentityConfiguration(builder.Configuration);

// Authentication & Authorization
builder.Services.AddSocialAuthenticationConfiguration(builder.Configuration);

// Interactive AspNetUser (logged in)
// NetDevPack.Identity dependency
builder.Services.AddAspNetUserConfiguration();

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

// Configure

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/error/500");
    app.UseStatusCodePagesWithRedirects("/error/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// NetDevPack.Identity dependency
app.UseAuthConfiguration();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
