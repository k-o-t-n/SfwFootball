using System.Security.Claims;
using System.Web.Mvc;

namespace Sfw.Football.Authentication
{
    public abstract class AuthenticatedController : Controller
    {
        public AuthenticatedUser CurrentUser
        {
            get
            {
                return new AuthenticatedUser(this.User as ClaimsPrincipal);
            }
        }
    }
}