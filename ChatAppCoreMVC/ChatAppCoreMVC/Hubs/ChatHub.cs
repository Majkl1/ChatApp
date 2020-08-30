using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAppCoreMVC.Services;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppCoreMVC.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppConfig _appconfig;

        public ChatHub(AppConfig onlineUsers)
        {
            _appconfig = onlineUsers;
        }
        public async Task SendMessage(string userFrom, string userTo, string message, 
                                      string connectionIdFrom, string connectionIdTo)
        {
            var connectionIds = new List<string>();
            connectionIds.Add(connectionIdFrom);
            connectionIds.Add(connectionIdTo);
            await Clients.Clients(connectionIds).SendAsync("ReceiveMessage", userFrom, userTo, message);
            string s = Context.ConnectionId;
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public string GetConnectionIdOfUser(string username)
        {
            foreach (UserConfig u in _appconfig.OnlineUsers)
            {
                if (u.Username == username)
                {
                    return u.ConnectionId;
                }
            }
            return null;
        }
        public void SetConnectionId(string username, string id)
        {
            foreach(UserConfig u in _appconfig.OnlineUsers)
            {
                if(u.Username == username)
                {
                    u.ConnectionId = id;
                    break;
                }
            }
        }



        
    }
}
