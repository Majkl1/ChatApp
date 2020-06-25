using System;
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

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private readonly UserConfig _userConfig;
        //private readonly UserManager<UserConfig> _userManager;

        public ChatController(UserConfig userConfig)
        {
            _userConfig = userConfig;

        }

        [Route("")]
        [HttpGet]
        public IActionResult Index(/*[FromServices] UserConfig _userConfig*/)
        {
            ChatData data = new ChatData(_userConfig.LoggedUsername);
            return View(data);
        }

        [Route("user/{nameTo}")]
        [HttpGet]
        public IActionResult User(string nameTo)
        {
            UserChatData data = new UserChatData(_userConfig.LoggedUsername, nameTo);
            return View(data);
        }

        [HttpPost]
        public IActionResult SendMessageToUser(string nameTo)
        {
            string text = Request.Form["msgText"];
            CommunicationWithDB.SendUserMessage(_userConfig.LoggedUsername, nameTo, text);
            return Redirect("/api/chat/user/" + nameTo);
        }

    }
}