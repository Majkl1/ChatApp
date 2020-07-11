using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppCoreMVC.Services
{
    public class OnlineUsers
    {
        //public List<string> AllUsers { get; private set; }
        public List<UserConfig> AllUsers { get; set; }
        public Queue<UserConfig> LoggingUsers { get; set; }

        public OnlineUsers()
        {
            AllUsers = new List<UserConfig>();
            LoggingUsers = new Queue<UserConfig>();
        }

        public bool Login(string username)
        {
            LoggingUsers.Enqueue(new UserConfig(username));
            return true;
        }

        public UserConfig UserLoaded()
        {
            if (LoggingUsers.Count == 0) return null;
            UserConfig user = LoggingUsers.Dequeue();
            AllUsers.Add(user);
            return user;
        }
    }
}
