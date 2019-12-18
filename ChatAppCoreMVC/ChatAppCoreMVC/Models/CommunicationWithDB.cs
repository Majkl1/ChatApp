using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAppCoreMVC.Models.DatabaseContext;

namespace ChatAppCoreMVC.Models
{
    public static class CommunicationWithDB
    {
        public static bool Login(string username)
        {
            bool exists = false;
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                //output = context.User.FirstOrDefault(u => u.Username == username).Username;
                foreach (User u in context.User)
                {
                    if (u.Username == username)
                    {
                        exists = true;
                        break;
                    }
                }
            }
            return exists;
        }
        public static bool Register(string username)
        {
            bool newUsername = true;
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                foreach (User u in context.User)
                {
                    if (u.Username == username)
                    {
                        newUsername = false;
                        break;
                    }
                }
                if (newUsername)
                {
                    User u = new User();
                    u.Username = username;
                    u.Password = "123";
                    context.User.Add(u);
                }
                context.SaveChanges();
            }
            return newUsername;
        }
        public static int GetUserId(string username)
        {
            int id = -1;
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                //output = context.User.FirstOrDefault(u => u.Username == username).Username;
                foreach (User u in context.User)
                {
                    if (u.Username == username)
                    {
                        id = u.IdUser;
                        break;
                    }
                }
            }
            return id;
        }
        public static List<string> GetAllUsernames()
        {
            List<string> usernames = new List<string>();
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                //output = context.User.FirstOrDefault(u => u.Username == username).Username;
                foreach (User u in context.User)
                {
                    usernames.Add(u.Username);
                }
            }
            return usernames;
        }
        
        public static List<string> GetAllUsernames(string username)
        {
            List<string> usernames = new List<string>();
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                //output = context.User.FirstOrDefault(u => u.Username == username).Username;
                foreach (User u in context.User)
                {
                    if (u.Username != username)
                    {
                        usernames.Add(u.Username);
                    }
                }
            }
            return usernames;
        }
        public static List<Message> GetAllUserMessages(string userFrom, string userTo)
        {
            List<Message> messages = new List<Message>();
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                User user1 = context.User.FirstOrDefault(u => u.Username == userFrom);
                User user2 = context.User.FirstOrDefault(u => u.Username == userTo);
                foreach (Message m in context.Message)
                {
                    if ((user1.IdUser == m.IdUserTo && user2.IdUser == m.IdUserFrom) || (user2.IdUser == m.IdUserTo && user1.IdUser == m.IdUserFrom))
                    {
                        messages.Add(m);
                    }
                }
            }
            return messages;
        }
        public static void SendUserMessage(string from, string to, string content)
        {
            //using (ChatDatabaseContext context = new ChatDatabaseContext())
            //{

            //}
            using (ChatDatabaseContext context = new ChatDatabaseContext())
            {
                User userFrom = context.User.FirstOrDefault(u => u.Username == from);
                User userTo = context.User.FirstOrDefault(u => u.Username == to);
                Message m = new Message();
                m.IdUserFrom = userFrom.IdUser;
                m.IdUserTo = userTo.IdUser;
                m.Content = content;
                context.Message.Add(m);
                context.SaveChanges();
            }
        }
    }
}
