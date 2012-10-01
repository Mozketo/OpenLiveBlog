using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenLiveBlog.Infrastructure.Hubs
{
    public class ConsoleHub : Hub
    {
        public void Send(string message)
        {
            // Call the addMessage method on all clients
            if (Clients == null)
                return;
            Clients.addMessage(message);
        }
    }
}