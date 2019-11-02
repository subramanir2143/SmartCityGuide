using Microsoft.AspNet.SignalR;
using System;
using System.Linq;

namespace AIeSCT.Web.Hubs
{
    public class ToggleState : Hub
    {
        public void Send(Guid id, bool availability)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ToggleState>();
            context.Clients.All.toggle(id,availability);
            
        }
    }
}