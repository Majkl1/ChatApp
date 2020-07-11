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
        private readonly OnlineUsers _onlineUsers;
        private readonly UserConfig _user;

        public ChatController(OnlineUsers onlineUsers)
        {
            _onlineUsers = onlineUsers;
            _user = _onlineUsers.UserLoaded();
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            ChatData data = new ChatData(_user.Username, _onlineUsers);
            //ChatData data = new ChatData("Majkl", _onlineUsers);
            return View(data);
        }

        //[Route("initialize/{nameFrom}/{nameTo}")]
        //[HttpGet]
        //public IActionResult InitializeUserTo(string nameFrom, string nameTo)
        //{
        //    _onlineUsers.Login(nameFrom);
        //    return Redirect("../../user/" + nameTo);
        //    //return NoContent();
        //}

        [Route("user/{nameTo}")]
        [HttpGet]
        public IActionResult User(string nameTo)
        {
            UserChatData data = new UserChatData(_user.Username, nameTo, _onlineUsers);
            //UserChatData data = new UserChatData("Majkl", nameTo, _onlineUsers);
            return View(data);
        }

        [HttpPost]
        public IActionResult SendMessageToUser(string nameTo)
        {
            string text = Request.Form["msgText"];
            CommunicationWithDB.SendUserMessage(_user.Username, nameTo, text);
            return NoContent();
        }

    }
}