using Microsoft.AspNet.Identity;
using Sfw.Football.Authentication;
using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    public class AdminController : AuthenticatedController
    {
        private UserManager<AuthenticatedUser> _userManager;

        public AdminController() : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AdminController(UserManager<AuthenticatedUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new AdminModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(AdminModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userManager.ChangePasswordAsync(CurrentUser.Id, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("logout", "auth");
            }

            foreach (var errorText in result.Errors)
            {
                ModelState.AddModelError(string.Empty, errorText);
            }

            return View(model);
        }
    }
}