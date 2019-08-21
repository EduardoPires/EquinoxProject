using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equinox.Infra.CrossCutting.Identity.Authorization.Jwt
{
    public static class TokenExtensions
    {
        private static TokenConfigurations _tokenConfigurations;
        public static TokenConfigurations GetTokenConfigurations(this IConfiguration configuration, string name)
        {
            if (_tokenConfigurations == null)
            {
                _tokenConfigurations = configuration.GetSection(name).Get<TokenConfigurations>();
            }
            return _tokenConfigurations;
        }
    }
}
