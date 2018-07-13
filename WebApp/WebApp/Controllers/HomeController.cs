using SignalRClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApp.Controllers
{
    public class HomeController : ApiController
    {
        private SignalRClient.SignalRClient _signalRClient;

        public HomeController()
        {
            _signalRClient = new SignalRClient.SignalRClient();
            this.ConnectClient();
        }

        private void ConnectClient()
        {
            this._signalRClient.Connect();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            _signalRClient.TriggerNotify("Sent from HomeController!");
            return Ok("Hallo Welt!");
        }

        // Send messages with URL like: /api/Home/MyMessage?text=my text
        [HttpGet]
        public IHttpActionResult MyMessage(string text)
        {
            _signalRClient.TriggerNotify(text);
            return Ok(text);
        }

    }
}
