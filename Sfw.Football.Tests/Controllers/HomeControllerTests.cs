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
        private IStandingsModelBuilder standingsModelBuilder;
        private HomeController controller;

        public HomeControllerTests()
        {
            standingsModelBuilder = A.Fake<IStandingsModelBuilder>();
            controller = new HomeController(standingsModelBuilder);
        }

        [Fact]
        public void IndexReturnsView()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }        
    }
}
