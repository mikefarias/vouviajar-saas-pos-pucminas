using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace VouViajar.Auth.Application.Extensions
{
    public static class Autorizacao
    {
        public static bool ValidarClaimUsuario(HttpContext context, string nomeClaim, string valorClaim)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == nomeClaim && c.Value.Contains(valorClaim));
        }
    }

    public class ClaimsAutorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAutorizeAttribute(string nomeClaim, string valorClaim) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(nomeClaim, valorClaim) };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
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

            if (!Autorizacao.ValidarClaimUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}