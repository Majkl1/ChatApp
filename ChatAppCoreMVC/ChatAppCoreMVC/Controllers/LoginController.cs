using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
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
                AppConfig.LoggedUsername = username;
                return Redirect("/api/chat");
            }
            else
            {
                return Redirect("/api/login");
            }
        }
    }
}