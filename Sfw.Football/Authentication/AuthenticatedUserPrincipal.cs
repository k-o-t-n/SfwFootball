using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Sfw.Football.Authentication
{
    public class AuthenticatedUserPrincipal : ClaimsPrincipal
    {
        public AuthenticatedUserPrincipal(ClaimsPrincipal principal) : base(principal)
        {
        }

        public string Id
        {
            get
            {
                return this.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public string Name
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Email
        {
            get
            {
                return this.FindFirst(ClaimTypes.Email).Value;
            }
        }
    }
}