using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient
{
    public class SignalRClient
    {
        private IHubProxy _proxy;
        private HubConnection _connection;

        // Connecting to the hub named: MyHub
        public void Connect()
        {
            _connection = new HubConnection("http://localhost:51103");
            _proxy = _connection.CreateHubProxy("MyHub");

            // Waiting for the connection to be established. Alternative, use await-async.
            _connection.Start().Wait();
        }

        // Function to fire Notification for subcribers. Passing message to the invoked method.
        public void TriggerNotify(string messageFromController)
        {
            _proxy.Invoke("NotifyAllClients", messageFromController);
        }
    }
}
