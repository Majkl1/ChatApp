using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DatabaseContext
{
    public partial class Group
    {
        public Group()
        {
            BelongsTo = new HashSet<BelongsTo>();
            GroupMessage = new HashSet<GroupMessage>();
        }

        public int IdGroup { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BelongsTo> BelongsTo { get; set; }
        public virtual ICollection<GroupMessage> GroupMessage { get; set; }
    }
}
