using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DatabaseContext
{
    public partial class Friendship
    {
        public int IdFriendship { get; set; }
        public int IdUser1 { get; set; }
        public int IdUser2 { get; set; }

        public virtual User IdUser1Navigation { get; set; }
        public virtual User IdUser2Navigation { get; set; }
    }
}
