using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Equinox.Infra.CrossCutting.Identity.Authorization
{
    internal class RequerimentClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequerimentClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorizationValidation.UserHasValidClaim(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}