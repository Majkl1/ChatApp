using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Models;
using Chat.AppConfiguration;

namespace Chat.Controllers
{
    public class ChatController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            EmptyChatData conv = new EmptyChatData(AppConfig.LoggedUser.Username);
            return View(conv);
        }

        [HttpGet]
        public ActionResult User(string nameTo)
        {
            UserChatData conv = new UserChatData(AppConfig.LoggedUser.Username, nameTo);
            return View(conv);
        }

        [HttpPost]
        public ActionResult WriteToUser(string nameTo)
        {
            string text = Request.Form["msgText"];
            CommunicationWithDB.SendUserMessage(AppConfig.LoggedUser.Username, nameTo, text);
            return Redirect("/chat/user?nameTo=" + nameTo);
        }

        [HttpGet]
        public ActionResult NewFriend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFriend()
        {
            string friendName = Request.Form["friendName"];
            CommunicationWithDB.AddNewFriend(AppConfig.LoggedUser.Username, friendName);
            return Redirect("/chat");
        }

        [HttpGet]
        public ActionResult Group(string groupName)
        {
            GroupChatData conv = new GroupChatData(AppConfig.LoggedUser.Username, groupName);
            return View(conv);
        }

        [HttpGet]
        public ActionResult NewGroup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MakeNewGroup()
        {
            string groupName = Request.Form["groupName"];
            CommunicationWithDB.MakeNewGroup(AppConfig.LoggedUser.Username, groupName);
            return Redirect("/chat");
        }

        [HttpPost]
        public ActionResult WriteToGroup(string groupName)
        {
            string text = Request.Form["msgText"];
            CommunicationWithDB.SendGroupMessage(groupName, AppConfig.LoggedUser.Username, text);
            return Redirect("/chat/group?groupName=" + groupName);
        }
    }
}