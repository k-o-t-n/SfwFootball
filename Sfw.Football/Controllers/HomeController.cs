using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.ModelBuilders;
using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IStandingsModelBuilder _standingsModelBuilder;

        public HomeController(IStandingsModelBuilder standingsModelBuilder)
        {
            _standingsModelBuilder = standingsModelBuilder;
        }

        public virtual ActionResult Index()
        {
            StandingsModel model = _standingsModelBuilder.BuildModel();
            return View(model);
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}