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
        public ChatData(string userFrom)
        {
            this.UserFrom = userFrom;
            this.Usernames = CommunicationWithDB.GetAllUsernames(userFrom);
            this.UserFromId = CommunicationWithDB.GetUserId(userFrom);
        }
    }
}
