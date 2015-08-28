using Sfw.Football.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    public class GamesHistoryController : Controller
    {
        private readonly IGameHistoryModelBuilder _gameHistoryModelBuilder;

        public GamesHistoryController(IGameHistoryModelBuilder gameHistoryModelBuilder)
        {
            _gameHistoryModelBuilder = gameHistoryModelBuilder;
        }

        public ActionResult Index()
        {
            var model = _gameHistoryModelBuilder.BuildModel();
            return View(model);
        }
    }
}