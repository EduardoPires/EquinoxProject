namespace Equinox.Services.Api.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Configuration
                        .SetBasePath(builder.Environment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();

            builder.Services.AddControllers();

            return builder;
        }
    }
}