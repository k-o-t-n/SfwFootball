using Microsoft.AspNet.Identity;
using Sfw.Football.Authentication;
using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    [AllowAnonymous]
    public partial class AuthController : Controller
    {
        private UserManager<AuthenticatedUser> _userManager;

        public AuthController(UserManager<AuthenticatedUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public virtual ActionResult Login(string returnUrl)
        {
            var model = new LoginModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindAsync(model.UserName, model.Password);

            if (user != null)
            {
                var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("UserNotFound", "Invalid email or password");

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult LogOut()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction(MVC.Home.Index());
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action(MVC.Home.Index());
            }

            return returnUrl;
        }
    }
}