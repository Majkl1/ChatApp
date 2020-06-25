using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppCoreMVC.Services
{
    public class OnlineUsers
    {
        public List<string> AllUsers { get; private set; }
        public Queue<string> LoggingUsers { get; set; }

        public OnlineUsers()
        {
            AllUsers = new List<string>();
            LoggingUsers = new Queue<string>();
        }

        public string UserLoaded()
        {
            string username = LoggingUsers.Dequeue();
            AllUsers.Add(username);
            return username;
        }
    }
}
