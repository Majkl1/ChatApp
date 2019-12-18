using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/register")]
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            string username = Request.Form["username"];
            if (CommunicationWithDB.Register(username))
            {
                AppConfig.LoggedUsername = username;
                return Redirect("/api/chat");
            }
            else
            {
                return Redirect("/api/register");
            }
        }
    }
}