using OpenLiveBlog.Models;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenLiveBlog.Infrastructure.Hubs
{
    public class Chat : Hub
    {
        public void Send(string message)
        {
            if (String.IsNullOrEmpty(message))
                return;

            message = message.Replace("\n", "<br/>");
            var model = new EntryViewModel { content = message };
            // Store the message for later.
            Controllers.HomeController.AddEntry(model);
            // Call the addMessage method on all clients
            Clients.addEntry(model);
        }

        public void Pulse()
        {
            Clients.addPulse(new { dateTime = DateTime.Now });
        }
    }
}