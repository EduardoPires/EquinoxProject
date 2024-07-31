using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Infra.CrossCutting.Identity.Data
{
    public class EquinoxIdentityContext : IdentityDbContext
    {
        public EquinoxIdentityContext(DbContextOptions<EquinoxIdentityContext> options) : base(options) { }
    }
}