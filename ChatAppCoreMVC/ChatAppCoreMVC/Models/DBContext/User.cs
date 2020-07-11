using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DBContext
{
    public partial class User
    {
        public User()
        {
            MessageIdUserFromNavigation = new HashSet<Message>();
            MessageIdUserToNavigation = new HashSet<Message>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Message> MessageIdUserFromNavigation { get; set; }
        public virtual ICollection<Message> MessageIdUserToNavigation { get; set; }
    }
}
