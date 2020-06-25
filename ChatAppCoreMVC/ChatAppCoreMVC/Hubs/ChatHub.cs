using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppCoreMVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userFrom, string userTo, string message, string connectionIdFrom, string connectionIdTo)
        {
            //await Clients.All.SendAsync("ReceiveMessage", userFrom, userTo, message);
            List<string> connectionIds = new List<string>();
            connectionIds.Add(connectionIdFrom);
            connectionIds.Add(connectionIdTo);
            await Clients.Clients(connectionIds).SendAsync("ReceiveMessage", userFrom, userTo, message);
            
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
