using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DBContext
{
    public partial class Message
    {
        public int IdMessage { get; set; }
        public int IdUserFrom { get; set; }
        public int IdUserTo { get; set; }
        public string Content { get; set; }

        public virtual User IdUserFromNavigation { get; set; }
        public virtual User IdUserToNavigation { get; set; }
    }
}
