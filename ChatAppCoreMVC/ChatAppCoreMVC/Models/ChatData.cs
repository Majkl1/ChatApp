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
        public AppConfig OnlineUsers { get; private set; }
        public ChatData(string userFrom, AppConfig onlineUsers, CommunicationWithDB db)
        {
            this.UserFrom = userFrom;
            this.Usernames = db.GetAllUsernames(userFrom);
            this.UserFromId = db.GetUserId(userFrom);
            this.OnlineUsers = onlineUsers;
        }
    }
}
