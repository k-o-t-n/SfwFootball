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
    public partial class TeamGenerationController : Controller
    {
        private readonly ITeamGenerationModelBuilder _teamGenerationModelBuilder;
        private readonly ITeamDisplayModelBuilder _teamDisplayModelBuilder;

        public TeamGenerationController(ITeamGenerationModelBuilder teamGenerationModelBuilder,
            ITeamDisplayModelBuilder teamDisplayModelBuilder)
        {
            _teamGenerationModelBuilder = teamGenerationModelBuilder;
            _teamDisplayModelBuilder = teamDisplayModelBuilder;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            TeamGenerationModel model = _teamGenerationModelBuilder.BuildModel();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Index(FormCollection formCollection)
        {
            var selectedValues = formCollection.GetValues("selectCheckBox");
            if (selectedValues != null && selectedValues.Count() > 1)
            {
                var selectedIds = selectedValues.Select(int.Parse).ToList();
                TempData["selectedIds"] = selectedIds;
                return RedirectToAction(MVC.TeamGeneration.Display());
            }
            return RedirectToAction(MVC.TeamGeneration.Index());
        }

        [HttpGet]
        public virtual ActionResult Display()
        {
            List<int> selectedIds = (List<int>)TempData["selectedIds"];
            if (selectedIds != null && selectedIds.Count() > 1)
            {
                TeamDisplayModel model = _teamDisplayModelBuilder.BuildModel(selectedIds);
                return View(model);
            }
            return RedirectToAction(MVC.TeamGeneration.Index());
        }

        [HttpPost]
        public virtual ActionResult Regenerate(TeamDisplayModel model)
        {
            List<int> selectedIds = model.Team1.Select(p => p.Id).Union(model.Team2.Select(p => p.Id)).ToList();
            TempData["selectedIds"] = selectedIds;
            return RedirectToAction(MVC.TeamGeneration.Display());
        }
    }
}