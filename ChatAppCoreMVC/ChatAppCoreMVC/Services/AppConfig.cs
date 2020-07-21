using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppCoreMVC.Services
{
    public class AppConfig
    {
        public List<UserConfig> OnlineUsers { get; private set; }
        public string ConnectionString { get; }

        public AppConfig()
        {
            OnlineUsers = new List<UserConfig>();
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.secret.json", optional: true)
              .Build();
            ConnectionString = config.GetConnectionString("ChatAppDB");
        }

        public bool Login(string username)
        {
            OnlineUsers.Add(new UserConfig(username));
            return true;
        }
    }
}
