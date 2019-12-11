using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class UserChatData : ChatData
    {
        public User User1 { get; private set; }
        public User User2 { get; private set; }
        public List<Message> Messages { get; private set; }

        public UserChatData(string name1, string name2) : base(true, false)
        {
            SetProperties(name1, name2);
        }

        private void SetProperties(string name1, string name2)
        {
            Messages = new List<Message>();
            base.AvailableUsers = CommunicationWithDB.GetAllAvailableUsers(name1);
            base.AvailableGroups = CommunicationWithDB.GetAllAvailableGroups(name1);
            User1 = CommunicationWithDB.GetUser(name1);
            User2 = CommunicationWithDB.GetUser(name2);
            Messages = CommunicationWithDB.GetAllUserMessages(name1, name2);
        }
    }
}