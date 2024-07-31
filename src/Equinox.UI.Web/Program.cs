using Equinox.UI.Web.Configurations;
using Equinox.Infra.CrossCutting.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adding Services
builder.AddMvcConfiguration()                   // Entire Equinox MVC Config
       .AddDatabaseConfiguration()              // Setting DBContexts
       .AddWebIdentityConfiguration()           // ASP.NET Identity Config
       .AddAutoMapperConfiguration()            // AutoMapper Config
       .AddMediatRConfiguration()               // Adding MediatR for Domain Events and Notifications
       .AddDependencyInjectionConfiguration();  // DotNet Native DI Abstraction

var app = builder.Build();

// Configure Services
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage()
       .UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/error/500")
       .UseStatusCodePagesWithRedirects("/error/{0}")
       .UseHsts();
}

app.UseHttpsRedirection()
   .UseStaticFiles()
   .UseRouting()
   .UseAuthentication()
   .UseAuthorization();

app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
