using FakeItEasy;
using Sfw.Football.Controllers;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.ModelBuilders;
using System.Web.Mvc;
using Xunit;

namespace Sfw.Football.Tests.Controllers
{
    public class HomeControllerTests
    {
        private IPlayersRepository playersRepository;
        private ITeamGenerationModelBuilder modelBuilder;
        private HomeController controller;

        public HomeControllerTests()
        {
            playersRepository = A.Fake<IPlayersRepository>();
            modelBuilder = A.Fake<ITeamGenerationModelBuilder>();
            controller = new HomeController(playersRepository, modelBuilder);
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
