using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Models;

namespace Chat.AppConfiguration
{
    public static class AppConfig
    {
        public static bool LoggedIn { get; set; }
        public static User LoggedUser { get; set; }

    }
}