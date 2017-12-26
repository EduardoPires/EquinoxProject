using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Equinox.Infra.CrossCutting.Identity.Authorization
{
    public class ClaimsRequirementHandler : AuthorizationHandler<ClaimRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       ClaimRequirement requirement)
        {

            if(context.User.Claims.Any(c => c.Type == requirement.ClaimName && requirement.ClaimValue == c.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
