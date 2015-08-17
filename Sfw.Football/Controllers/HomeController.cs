using Sfw.Football.Massive.Entities;
using Sfw.Football.Massive.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Players> _playerRepository;
        public HomeController()
        {
            // Sort out autofac!
            _playerRepository = new Repository<Players>();
        }

        public ActionResult Index()
        {
            var players = _playerRepository.All();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}