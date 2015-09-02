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
    public partial class AdminController : Controller
    {
        private UserManager<AuthenticatedUser> _userManager;

        public AdminController(UserManager<AuthenticatedUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public virtual ActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            var model = new NewUserViewModel();
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(NewUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AuthenticatedUser(model.UserName, model.Email);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("success");
            }
            else
            {
                foreach (var errorMessage in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                return View(model);
            }
        }
    }
}