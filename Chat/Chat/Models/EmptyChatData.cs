using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class EmptyChatData : ChatData
    {
        public User User { get; private set; }

        public EmptyChatData(string name) : base(false, false)
        {
            SetProperties(name);
        }

        private void SetProperties(string name)
        {
            base.AvailableUsers = CommunicationWithDB.GetAllAvailableUsers(name);
            base.AvailableGroups = CommunicationWithDB.GetAllAvailableGroups(name);
            User = CommunicationWithDB.GetUser(name);
        }
    }
}