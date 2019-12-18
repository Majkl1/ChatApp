using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DatabaseContext
{
    public partial class GroupMessage
    {
        public int IdGroupMessage { get; set; }
        public int IdGroup { get; set; }
        public int IdUserFrom { get; set; }
        public string Content { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual User IdUserFromNavigation { get; set; }
    }
}
