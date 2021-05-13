using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace TutorialTestAPI.Hubs
{
    [HubName("SampleHub")]
    public class SampleHub : Hub
    {
        public void Hello(string name)
        {
            Clients.Client(Context.ConnectionId).hello(name + "さん、こんにちは");
        }

        public void Send(string name, string text)
        {
            Clients.All.Receive(name + " : " + text);
        }
    }
}