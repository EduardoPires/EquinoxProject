using Equinox.Infra.CrossCutting.Identity.Authorization.Jwt.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equinox.Infra.CrossCutting.Identity.Authorization.Jwt.Services
{
    public class JwtAdapter : IJwtAdapter
    {
        private readonly IConfiguration _configuration;
        public JwtAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenConfigurations GetConfigurations(string name)
        {
            return _configuration.GetTokenConfigurations(name);
        }
    }
}
