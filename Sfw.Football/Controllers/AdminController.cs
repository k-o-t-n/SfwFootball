using Sfw.Football.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    public class AdminController : AuthenticatedController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}