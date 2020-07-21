using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAppCoreMVC.Models.DBContext;

namespace ChatAppCoreMVC.Models
{
    public class CommunicationWithDB
    {
        private readonly ChatAppDBContext _context;
        public CommunicationWithDB(ChatAppDBContext context)
        {
            _context = context;
        }

        public bool Login(string username, string hash)
        {
            bool exists = false;

            foreach (User u in _context.User)
            {
                if (u.Username == username && u.Password == hash)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
        public bool Register(string username, string hash)
        {
            bool newUsername = true;
            foreach (User u in _context.User)
            {
                if (u.Username == username)
                {
                    newUsername = false;
                    break;
                }
            }
            if (newUsername)
            {
                var u = new User();
                u.Username = username;
                u.Password = hash;
                _context.User.Add(u);
                _context.SaveChanges();
            }
            return newUsername;
        }
        public int GetUserId(string username)
        {
            int id = -1;
            foreach (User u in _context.User)
            {
                if (u.Username == username)
                {
                    id = u.IdUser;
                    break;
                }
            }
            return id;
        }
        public List<string> GetAllUsernames()
        {
            var usernames = new List<string>();
            foreach (User u in _context.User)
            {
                usernames.Add(u.Username);
            }
            return usernames;
        }
        
        public List<string> GetAllUsernames(string username)
        {
            var usernames = new List<string>();
            foreach (User u in _context.User)
            {
                if (u.Username != username)
                {
                    usernames.Add(u.Username);
                }
            }
            return usernames;
        }
        public List<Message> GetAllUserMessages(string userFrom, string userTo)
        {
            var messages = new List<Message>();
            User user1 = _context.User.FirstOrDefault(u => u.Username == userFrom);
            User user2 = _context.User.FirstOrDefault(u => u.Username == userTo);
            foreach (Message m in _context.Message)
            {
                if ((user1.IdUser == m.IdUserTo && user2.IdUser == m.IdUserFrom) || (user2.IdUser == m.IdUserTo && user1.IdUser == m.IdUserFrom))
                {
                    messages.Add(m);
                }
            }
            return messages;
        }
        public void SendUserMessage(string from, string to, string content)
        {
            User userFrom = _context.User.FirstOrDefault(u => u.Username == from);
            User userTo = _context.User.FirstOrDefault(u => u.Username == to);
            var m = new Message();
            m.IdUserFrom = userFrom.IdUser;
            m.IdUserTo = userTo.IdUser;
            m.Content = content;
            _context.Message.Add(m);
            _context.SaveChanges();
        }
    }
}
