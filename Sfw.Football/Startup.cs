using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Sfw.Football.Authentication;
using Sfw.Football.DataAccess.Repositories;
using System;

namespace Sfw.Football
{
    public class Startup
    {
        public static Func<UserManager<AuthenticatedUser>> UserManagerFactory { get; private set; }
        private IIdentityRepository<AuthenticatedUser> _identities = new IdentityRepository<AuthenticatedUser>();

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            UserManagerFactory = () =>
            {
                var userManager = new UserManager<AuthenticatedUser>(new UserStore<AuthenticatedUser>(_identities));

                return userManager;
            };
        }
    }
}
