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
    public class AuthController : Controller
    {
        private UserManager<AuthenticatedUser> _userManager;

        public AuthController(UserManager<AuthenticatedUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindAsync(model.UserName, model.Password);
            
            //temp auth hack
            if (user != null)
            {
                var identity = await _userManager.CreateIdentityAsync(user, "ApplicationCookie");
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}