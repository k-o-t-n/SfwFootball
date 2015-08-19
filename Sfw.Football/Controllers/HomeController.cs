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
    public class HomeController : Controller
    {
        private readonly ITeamGenerationModelBuilder _teamGenerationModelBuilder;
        private readonly ITeamDisplayModelBuilder _teamDisplayModelBuilder;
        private readonly IStandingsModelBuilder _standingsModelBuilder;

        public HomeController(ITeamGenerationModelBuilder teamGenerationModelBuilder, 
            ITeamDisplayModelBuilder teamDisplayModelBuilder,
            IStandingsModelBuilder standingsModelBuilder)
        {
            _teamGenerationModelBuilder = teamGenerationModelBuilder;
            _teamDisplayModelBuilder = teamDisplayModelBuilder;
            _standingsModelBuilder = standingsModelBuilder;
        }

        public ActionResult Index()
        {
            StandingsModel model = _standingsModelBuilder.BuildModel();
            return View(model);
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

        [HttpGet]
        public ActionResult TeamGeneration()
        {
            TeamGenerationModel model = _teamGenerationModelBuilder.BuildModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult TeamGeneration(FormCollection formCollection)
        {
            if (formCollection.GetValues("selectCheckBox") != null && formCollection.GetValues("selectCheckBox").Count() > 1)
            {
                var selectedIds = formCollection.GetValues("selectCheckBox").Select(int.Parse).ToList();
                TempData["selectedIds"] = selectedIds;
                return RedirectToAction("TeamDisplay");
            }
            return RedirectToAction("TeamGeneration");
        }

        [HttpGet]
        public ActionResult TeamDisplay()
        {
            IEnumerable<int> selectedIds = (IEnumerable<int>)TempData["selectedIds"];
            if (selectedIds != null && selectedIds.Count() > 1)
            {
                TeamDisplayModel model = _teamDisplayModelBuilder.BuildModel(selectedIds);
                return View(model);
            }
            return RedirectToAction("TeamGeneration");
        }
    }
}