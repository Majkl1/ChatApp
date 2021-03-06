﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ChatAppCoreMVC.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ChatAppCoreMVC.Controllers
{
    [Route("chat")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly AppConfig _onlineUsers;
        private readonly CommunicationWithDB _communicationWithDB;
        public ChatController(AppConfig onlineUsers, CommunicationWithDB db)
        {
            _onlineUsers = onlineUsers;
            _communicationWithDB = db;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            string username = HttpContext.User.Identities.ToArray()[0].Claims.ToArray()[0].Value;
            var data = new ChatData(username, _onlineUsers, _communicationWithDB);
            
            return View(data);
        }

        [Route("user/{nameTo}")]
        [HttpGet]
        public new IActionResult User(string nameTo)
        {
            string username = HttpContext.User.Identities.ToArray()[0].Claims.ToArray()[0].Value;
            var data = new UserChatData(username, nameTo, _onlineUsers, _communicationWithDB);
            return View(data);
        }

        [HttpPost]
        public IActionResult SendMessageToUser(string nameTo)
        {
            string text = Request.Form["msgText"];

            string username = HttpContext.User.Identities.ToArray()[0].Claims.ToArray()[0].Value;

            _communicationWithDB.SendUserMessage(username, nameTo, text);
            return NoContent();
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user-login");
            return Redirect(Url.Action("", "login"));
        }
    }
}