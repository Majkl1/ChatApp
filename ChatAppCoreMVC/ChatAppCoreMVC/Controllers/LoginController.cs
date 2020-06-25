using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;
using ChatAppCoreMVC.Services;
using Microsoft.Extensions.Options;

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly UserConfig _userConfig;
        //private readonly OnlineUsers _onlineUsers;

        //public LoginController(OnlineUsers onlineUsers)
        //{
        //    _onlineUsers = onlineUsers;
        //}

        public LoginController(UserConfig userConfig)
        {
            _userConfig = userConfig;
        }

        //public LoginController(IOptionsSnapshot<UserConfig> userConfig)
        //{

        //    _userConfig = userConfig.Value;
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            string username = Request.Form["username"];
            if (CommunicationWithDB.Login(username))
            {
                //AppConfig.LoggedUsername = username;

                _userConfig.LoggedUsername = username;

                //_onlineUsers.LoggingUsers.Enqueue(username);

                return Redirect("/api/chat");
            }
            else
            {
                return Redirect("/api/login");
            }
        }
    }
}