using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class GroupChatData : ChatData
    {
        public User User { get; private set;}
        public Group Group { get; private set; }
        public List<GroupMessage> Messages { get; private set; }

        public GroupChatData(string username, string groupName) : base(true, true)
        {
            SetAllProperties(username, groupName);
        }

        private void SetAllProperties(string username, string groupName)
        {
            Messages = new List<GroupMessage>();
            base.AvailableUsers = CommunicationWithDB.GetAllAvailableUsers(username);
            base.AvailableGroups = CommunicationWithDB.GetAllAvailableGroups(username);
            User = CommunicationWithDB.GetUser(username);
            Group = CommunicationWithDB.GetGroup(groupName);
            Messages = CommunicationWithDB.GetAllGroupMessages(groupName);
        }
    }
}