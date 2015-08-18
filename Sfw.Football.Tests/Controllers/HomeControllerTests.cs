﻿using FakeItEasy;
using Sfw.Football.Controllers;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.ModelBuilders;
using System.Web.Mvc;
using Xunit;

namespace Sfw.Football.Tests.Controllers
{
    public class HomeControllerTests
    {
        private IPlayerRepository playersRepository;
        private ITeamGenerationModelBuilder modelBuilder;
        private HomeController controller;

        public HomeControllerTests()
        {
            modelBuilder = A.Fake<ITeamGenerationModelBuilder>();
            controller = new HomeController(modelBuilder);
        }

        [Fact]
        public void IndexReturnsView()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void TeamGenerationReturnsView()
        {
            ViewResult result = controller.TeamGeneration() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
