using Ninject;
using Ninject.Web.Common;
using SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace OpenLiveBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            // Register a resolver for SignalR
            //http://weblogs.asp.net/davidfowler/archive/2012/05/04/api-improvements-made-in-signalr-0-5.aspx
            GlobalHost.DependencyResolver = new Infrastructure.NinjectDependencyResolver(base.Kernel);
            RouteTable.Routes.MapHubs();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Enumerable.Range(0, 5).ToList().ForEach(m =>
            {
                System.Diagnostics.Trace.WriteLine("Kitteh " + m);
                System.Threading.Thread.Sleep(1000);
            });
            
        }
    }
}