using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;
using ChatAppCoreMVC.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ChatAppCoreMVC.Controllers
{
    [Route("register")]
    public class RegisterController : Controller
    {
        private readonly AppConfig _appConfig;
        private readonly CommunicationWithDB _communicationWithDB;
        private readonly HashAlgorithm _hashAlgorithm;

        public RegisterController(AppConfig appConfig, CommunicationWithDB db, HashAlgorithm hashAlgorithm)
        {
            _appConfig = appConfig;
            _communicationWithDB = db;
            _hashAlgorithm = hashAlgorithm;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            string username = Request.Form["username"];
            string plainPassword = Request.Form["password"];

            string hash = _hashAlgorithm.GetHash(plainPassword);
            if (_communicationWithDB.Register(username, hash))
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
                Response.Cookies.Append("invalid-register", "true");
                return Redirect("/register");
            }

        }
    }
}