using Microsoft.OpenApi.Models;

namespace Equinox.Services.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Equinox Project",
                    Description = "Equinox API Swagger surface",
                    Contact = new OpenApiContact { Name = "Eduardo Pires", Email = "contato@eduardopires.net.br", Url = new Uri("http://www.eduardopires.net.br") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/EduardoPires/EquinoxProject/blob/master/LICENSE") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the JWT like: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {}
                    }
                });

                // Excluding ASP.NET Identity endpoints
                s.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var relativePath = apiDesc.RelativePath;

                    // List of avoid patches
                    var identityEndpoints = new[]
                    {
                        "register",
                        "manage",
                        "refresh",
                        "login",
                        "confirmEmail",
                        "resendConfirmationEmail",
                        "forgotPassword",
                        "resetPassword"                        
                    };

                    // Validating if the endpoint is avoided
                    foreach (var endpoint in identityEndpoints)
                    {
                        if (relativePath.Contains(endpoint, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }

                    return true;
                });

            });

            return builder;
        }

        public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}