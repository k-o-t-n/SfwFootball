﻿using Sfw.Football.Massive.Entities;
using Sfw.Football.Massive.Repositories;
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

        public HomeController()
        {
            _playerRepository = new PlayersRepository();
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
    }
}