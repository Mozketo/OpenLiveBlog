using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;
using SignalR.Hubs;

namespace OpenLiveBlog.Infrastructure
{
    public class SignalRTraceListener : System.Diagnostics.TraceListener
    {
        public override void Write(string message)
        {
            //var connectionManager = GlobalHost.DependencyResolver.Resolve<SignalR.IConnectionManager>();
            //dynamic clients = connectionManager.GetClients<Infrastructure.Hubs.ConsoleHub>();
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<Infrastructure.Hubs.ConsoleHub>();
            if (context.Clients == null)
                return;
            context.Clients.addMessage(DateTime.Now.ToString("yy-MM-dd H:mm:ss") + " - " + message);
        }

        public override void WriteLine(string message)
        {
            //var connectionManager = GlobalHost.DependencyResolver.Resolve<SignalR.IConnectionManager>();
            //dynamic clients = connectionManager.GetClients<Infrastructure.Hubs.ConsoleHub>();
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<Infrastructure.Hubs.ConsoleHub>();
            if (context.Clients == null)
                return;
            context.Clients.addMessage(DateTime.Now.ToString("yy-MM-dd H:mm:ss") + " - " + message);
        }
    }
}