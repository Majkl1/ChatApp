using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppCoreMVC.Services
{
    public class UserConfig : IdentityUser
    {
        public string LoggedUsername { get; set; }

        public UserConfig(/*string username*/)
        {
            //LoggedUsername = username;
        }
    }
}
