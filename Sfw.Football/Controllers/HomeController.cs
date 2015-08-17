using Sfw.Football.Massive.Entities;
using Sfw.Football.Massive.Repositories;
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
        private readonly IPlayersRepository _playerRepository;
        private readonly ITeamGenerationModelBuilder _teamGenerationModelBuilder;

        public HomeController(IPlayersRepository playersRepository, ITeamGenerationModelBuilder teamGenerationModelBuilder)
        {
            _playerRepository = playersRepository;
            _teamGenerationModelBuilder = teamGenerationModelBuilder;
        }

        public ActionResult Index()
        {
            var players = _playerRepository.All();
            ViewBag.Players = players;
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

        public ActionResult TeamGeneration()
        {
            TeamGenerationModel model = _teamGenerationModelBuilder.BuildModel();
            return View(model);
        }
    }
}