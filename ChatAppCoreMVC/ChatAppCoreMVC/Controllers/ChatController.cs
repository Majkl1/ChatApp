using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatAppCoreMVC.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ChatAppCoreMVC.Controllers
{
    [Route("api/chat")]
    public class ChatController : Controller
    {
        

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            ChatData data = new ChatData(AppConfig.LoggedUsername);
            
            return View(data);
        }

        [Route("user/{nameTo}")]
        [HttpGet]
        public IActionResult User(string nameTo)
        {
            UserChatData data = new UserChatData(AppConfig.LoggedUsername, nameTo);
            return View(data);
        }

        [HttpPost]
        public IActionResult SendMessageToUser(string nameTo)
        {
            string text = Request.Form["msgText"];
            CommunicationWithDB.SendUserMessage(AppConfig.LoggedUsername, nameTo, text);
            return Redirect("/api/chat/user/" + nameTo);
        }

    }
}