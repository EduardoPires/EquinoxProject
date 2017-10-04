using AutoMapper;

namespace Equinox.Application.AutoMapper
{
    public class AutoMapperConfig
    {       
        public static MapperConfiguration RegisterMappings()
        {
            //Get All Automapper.Profile Objects
            var profiles =
                (from type in typeof(AutoMapperConfig).Assembly.GetTypes()
                 where
                    typeof(Profile).IsAssignableFrom(type) &&
                    !type.IsAbstract &&
                    type.GetConstructor(Type.EmptyTypes) != null
                 select type).Select(d => (Profile)Activator.CreateInstance(d))
                   .ToArray();

            //Dynamically add AutoMapper profiles to mapper configuration
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            
            //Validate Mappings
            mapperConfig.AssertConfigurationIsValid();
            return mapperConfig;
        }
    }
}
