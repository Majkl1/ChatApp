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

        public UserChatData(string userFrom, string userTo, Services.AppConfig onlineUsers, CommunicationWithDB db) : base(userFrom, onlineUsers, db)
        {
            this.UserTo = userTo;
            this.Messages = db.GetAllUserMessages(userFrom, userTo);
            this.UserToId = db.GetUserId(userTo);
        }
    }
}
