using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public abstract class ChatData
    {
        public bool UserChosen { get; private set; }
        public bool GroupChat { get; private set; }
        public List<User> AvailableUsers { get; protected set; }
        public List<Group> AvailableGroups { get; protected set; }

        public ChatData(bool userChosen, bool groupChat)
        {
            this.UserChosen = userChosen;
            this.GroupChat = groupChat;
            this.AvailableUsers = new List<User>();
            this.AvailableGroups = new List<Group>();
        }

    }
}
