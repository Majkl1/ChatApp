using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppCoreMVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userFrom, string userTo, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userFrom, userTo, message);
        }
    }
}
