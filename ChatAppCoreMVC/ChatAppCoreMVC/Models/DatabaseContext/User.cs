using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DatabaseContext
{
    public partial class User
    {
        public User()
        {
            BelongsTo = new HashSet<BelongsTo>();
            FriendshipIdUser1Navigation = new HashSet<Friendship>();
            FriendshipIdUser2Navigation = new HashSet<Friendship>();
            GroupMessage = new HashSet<GroupMessage>();
            MessageIdUserFromNavigation = new HashSet<Message>();
            MessageIdUserToNavigation = new HashSet<Message>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BelongsTo> BelongsTo { get; set; }
        public virtual ICollection<Friendship> FriendshipIdUser1Navigation { get; set; }
        public virtual ICollection<Friendship> FriendshipIdUser2Navigation { get; set; }
        public virtual ICollection<GroupMessage> GroupMessage { get; set; }
        public virtual ICollection<Message> MessageIdUserFromNavigation { get; set; }
        public virtual ICollection<Message> MessageIdUserToNavigation { get; set; }
    }
}
