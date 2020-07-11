using ChatAppCoreMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppCoreMVC.Models
{
    public class ChatData
    {
        public List<string> Usernames { get; protected set; }
        public string UserFrom { get; protected set; }
        public int UserFromId { get; protected set; }
        public OnlineUsers OnlineUsers { get; private set; }
        public ChatData(string userFrom, OnlineUsers onlineUsers)
        {
            this.UserFrom = userFrom;
            this.Usernames = CommunicationWithDB.GetAllUsernames(userFrom);
            this.UserFromId = CommunicationWithDB.GetUserId(userFrom);
            this.OnlineUsers = onlineUsers;
        }
    }
}
