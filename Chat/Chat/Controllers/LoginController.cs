using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.AppConfiguration;
using Chat.Models;

namespace Chat.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //if (AppConfig.LoggedIn)
            //{
            //    return Redirect("/Chat");
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            string username = Request.Form["username"];
            User u = CommunicationWithDB.Login(username, "123");
            AppConfig.LoggedUser = u;

            return Redirect("/Chat");
        }
        
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewUser()
        {
            string username = Request.Form["username"];
            User u; 
            bool registered = CommunicationWithDB.Register(username, "123", out u);
            if (registered)
            {
                AppConfig.LoggedUser = u;
            }
            return Redirect("/Chat");
        }
    }
}