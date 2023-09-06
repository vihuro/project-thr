using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace API.AUTH.Service.JWT
{
    public class CustomAuthorize
    {
        public static bool ValidarClaimUsuario(HttpContext context, string claimName, string claimValue)
        {
            var permissions = claimValue.Split(',');
            if (!context.User.Identity.IsAuthenticated &&
               !context.User.Claims.Any(x => x.Type.ToUpper() == claimName.ToUpper())) return false;
            var auth = permissions.Any(x => context.User.Claims.Any(c => c.Value.ToUpper() == x.ToUpper()));

            var teste = context.User.Claims.ToList();

            for (int i = 0; i <= teste.Count; i++)
            {
                if (teste[i].Type == claimName)
                {
                    for (int j = 0; j < permissions.Length; j++)
                    {
                        if (permissions[j] == teste[i].Value)
                        {
                            return true;
                        }
                    }
                    break;
                }
            }

            return false;

        }
    }
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public RequisitoClaimFilter(Claim claims)
        {
            _claim = claims;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorize.ValidarClaimUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}

