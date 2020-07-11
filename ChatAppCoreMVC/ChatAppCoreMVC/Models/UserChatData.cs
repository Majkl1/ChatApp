using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAppCoreMVC.Models.DBContext;
using ChatAppCoreMVC.Services;

namespace ChatAppCoreMVC.Models
{
    public class UserChatData : ChatData
    {
        public string UserTo { get; private set; }
        public List<Message> Messages { get; private set; }
        public int UserToId { get; private set; }

        public UserChatData(string userFrom, string userTo, OnlineUsers onlineUsers) : base(userFrom, onlineUsers)
        {
            this.UserTo = userTo;
            this.Messages = CommunicationWithDB.GetAllUserMessages(userFrom, userTo);
            this.UserToId = CommunicationWithDB.GetUserId(userTo);
        }
    }
}
