﻿using Sfw.Football.ModelBuilders;
using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sfw.Football.Controllers
{
    [AllowAnonymous]
    public partial class HomeController : Controller
    {
        readonly IStandingsModelBuilder _standingsModelBuilder;

        public HomeController(IStandingsModelBuilder standingsModelBuilder)
        {
            _standingsModelBuilder = standingsModelBuilder;
        }

        public virtual ActionResult Index()
        {
            StandingsModel model = _standingsModelBuilder.BuildModel();
            return View(model);
        }
    }
}