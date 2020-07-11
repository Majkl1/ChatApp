using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;
using ChatAppCoreMVC.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.SignalR;
using ChatAppCoreMVC.Hubs;

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly OnlineUsers _onlineUsers;

        public LoginController(OnlineUsers onlineUsers)
        {
            _onlineUsers = onlineUsers;
        }

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
                _onlineUsers.Login(username);
                return Redirect("/api/chat");
            }
            else
            {
                return Redirect("/api/login");
            }
        }
    }
}