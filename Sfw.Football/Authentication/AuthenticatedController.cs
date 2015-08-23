using System.Security.Claims;
using System.Web.Mvc;

namespace Sfw.Football.Authentication
{
    public abstract class AuthenticatedController : Controller
    {
        public AuthenticatedUserPrincipal CurrentUser
        {
            get
            {
                return new AuthenticatedUserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }
}