using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppCoreMVC.Services
{
    public class UserConfig : IdentityUser
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }

        public UserConfig(string username)
        {
            Username = username;
        }
    }
}
