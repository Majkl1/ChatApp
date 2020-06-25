using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;
using ChatAppCoreMVC.Services;

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/register")]
    public class RegisterController : Controller
    {
        private readonly UserConfig _userConfig;
        //private readonly IUserConfig _userConfig;

        public RegisterController(UserConfig userConfig)
        {
            _userConfig = userConfig;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{
        //    string username = Request.Form["username"];
        //    if (CommunicationWithDB.Register(username))
        //    {
        //        _userConfig.LoggedUsername = username;
        //        return Redirect("/api/chat");
                
        //    }
        //    else
        //    {
        //        return Redirect("/api/register");
        //    }
        //}
    }
}