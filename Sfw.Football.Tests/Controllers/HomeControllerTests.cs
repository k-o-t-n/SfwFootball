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
        private ITeamGenerationModelBuilder teamGenerationModelBuilder;
        private ITeamDisplayModelBuilder teamDisplayModelBuilder;
        private IStandingsModelBuilder standingsModelBuilder;
        private HomeController controller;

        public HomeControllerTests()
        {
            teamGenerationModelBuilder = A.Fake<ITeamGenerationModelBuilder>();
            teamDisplayModelBuilder = A.Fake<ITeamDisplayModelBuilder>();
            standingsModelBuilder = A.Fake<IStandingsModelBuilder>();
            controller = new HomeController(
                teamGenerationModelBuilder, 
                teamDisplayModelBuilder, 
                standingsModelBuilder);
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
