using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equinox.Infra.CrossCutting.Identity.Authorization.Jwt.Interfaces
{
    public interface IJwtAdapter
    {
        TokenConfigurations GetConfigurations(string name);
    }
}
