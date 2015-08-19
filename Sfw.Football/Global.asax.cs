using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;

namespace Sfw.Football
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac setup
            var builder = new ContainerBuilder();
            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Register other types in assemblies
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(AppDomain.CurrentDomain.Load("Sfw.Football"));
            assemblies.Add(AppDomain.CurrentDomain.Load("Sfw.Football.DataAccess"));
            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
