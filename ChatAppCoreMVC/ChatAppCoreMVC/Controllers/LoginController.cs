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
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ChatAppCoreMVC.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly AppConfig _appConfig;
        private readonly CommunicationWithDB _communicationWithDB;
        private readonly HashAlgorithm _hashAlgorithm;

        public LoginController(AppConfig onlineUsers, CommunicationWithDB db, HashAlgorithm hashAlgorithm)
        {
            _appConfig = onlineUsers;
            _communicationWithDB = db;
            _hashAlgorithm = hashAlgorithm;
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
            string plainPassword = Request.Form["password"];
           
            string hash = _hashAlgorithm.GetHash(plainPassword);
            if (_communicationWithDB.Login(username, hash))
            {
                _appConfig.Login(username);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var userIdentity = new ClaimsIdentity(userClaims, "user identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/chat");
            }
            else
            {
                Response.Cookies.Append("invalid-login", "true");
                return Redirect("/login");
            }

        }

        [Route("authenticate")]
        public IActionResult Authenticate()
        {
            return Redirect("..");
        }
    }
}