using System;
using System.Collections.Generic;

namespace ChatAppCoreMVC.Models.DatabaseContext
{
    public partial class BelongsTo
    {
        public int IdUser { get; set; }
        public int IdGroup { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
