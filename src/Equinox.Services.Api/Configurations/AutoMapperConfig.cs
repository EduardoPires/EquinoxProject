using Equinox.Application.AutoMapper;

namespace Equinox.Services.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static WebApplicationBuilder AddAutoMapperConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            return builder;
        }
    }
}