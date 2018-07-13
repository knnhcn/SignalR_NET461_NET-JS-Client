using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Hubs
{
    [HubName("myhub")]
    public class MyHub : Hub
    {
        List<string> _connectedUsers = new List<string>();

        // OnConnect event fired if someone connects.
        public override Task OnConnected()
        {
            // Ensure that the group is added before completing 
            _connectedUsers.Add(Context.ConnectionId);
            return base.OnConnected();
        }

        // Function to send message to all subscribed clients.
        public void NotifyAllClients(string message)
        {
            Clients.All.hello(message);
        }
    }
}