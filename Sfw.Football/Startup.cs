using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sfw.Football.Startup))]
namespace Sfw.Football
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
