using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public static class CommunicationWithDB
    {
        public static List<User> GetAllAvailableUsers(string username)
        {
            List<User> availableUsers = new List<User>();
            using(ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                foreach(Friendship f in context.Friendships)
                {
                    if (f.User == user) availableUsers.Add(f.User1);
                    else if (f.User1 == user) availableUsers.Add(f.User);
                }
            }
            return availableUsers;
        }
        public static List<Message> GetAllUserMessages(string name1, string name2)
        {
            List<Message> messages = new List<Message>();
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User user1 = context.Users.FirstOrDefault(u => u.Username == name1);
                User user2 = context.Users.FirstOrDefault(u => u.Username == name2);
                foreach(Message m in context.Messages)
                {
                    if((m.User == user1 && m.User1 == user2) || (m.User == user2 && m.User1 == user1))
                    {
                        messages.Add(m);
                    }
                }
            }
            return messages;
        }
        public static void AddNewFriend(string username, string friendName)
        {
            if (IsFriend(username, friendName)) return;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User user1 = context.Users.FirstOrDefault(u => u.Username == username);
                User user2 = context.Users.FirstOrDefault(u => u.Username == friendName);
                Friendship f = new Friendship();
                f.User = user1;
                f.User1 = user2;
                context.Friendships.Add(f);
                context.SaveChanges();
            }
        }
        public static void SendUserMessage(string nameFrom, string nameTo, string content)
        {
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User userFrom = context.Users.FirstOrDefault(u => u.Username == nameFrom);
                User userTo = context.Users.FirstOrDefault(u => u.Username == nameTo);
                Message m = new Message();
                m.User = userFrom;
                m.User1 = userTo;
                m.Content = content;
                context.Messages.Add(m);
                context.SaveChanges();
            }
        }
        public static User GetUser(string username)
        {
            User user;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                user = context.Users.FirstOrDefault(u => u.Username == username);
            }
            return user;
        }
        public static User Login(string username, string password)
        {
            User user;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                user = context.Users.FirstOrDefault(u => (u.Username == username && u.Password == password));
            }
            return user;
        }
        public static bool Register(string username, string password, out User newUser)
        {
            newUser = null;
            if (containsUser(username)) return false;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                newUser = new User();
                newUser.Username = username;
                newUser.Password = password;
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            return true;
        }
        public static Group MakeNewGroup(string creatorName, string name)
        {
            Group g;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User creator = context.Users.FirstOrDefault(u => u.Username == creatorName);
                g = new Group();
                g.Name = name;
                g.Users.Add(creator);
                context.Groups.Add(g);
                context.SaveChanges();
            }
            return g;
        }
        public static void AddNewUserToGroup(string groupName, string username)
        {
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                Group group = context.Groups.FirstOrDefault(g => g.Name == groupName);
                group.Users.Add(user);
                context.SaveChanges();
            }
        }
        public static List<Group> GetAllAvailableGroups(string username)
        {
            List<Group> availableGroups = new List<Group>();
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                foreach(Group g in context.Groups)
                {
                    if (g.Users.Contains(user))
                    {
                        availableGroups.Add(g);
                    }
                }
            }
            return availableGroups;
        }
        public static Group GetGroup(string groupName)
        {
            Group group;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                group = context.Groups.FirstOrDefault(g => g.Name == groupName);
            }
            return group;
        }
        public static List<GroupMessage> GetAllGroupMessages(string groupName)
        {
            List<GroupMessage> messages = new List<GroupMessage>();
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                Group group = context.Groups.FirstOrDefault(g => g.Name == groupName);
                foreach(GroupMessage m in context.GroupMessages)
                {
                    if(m.Group == group)
                    {
                        messages.Add(m);
                    }
                }
            }
            return messages;
        }
        public static void SendGroupMessage(string groupName, string username, string content)
        {
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                Group group = context.Groups.FirstOrDefault(g => g.Name == groupName);
                GroupMessage m = new GroupMessage();
                m.User = user;
                m.Group = group;
                m.Content = content;
                context.GroupMessages.Add(m);
                context.SaveChanges();
            }
        }


        private static bool IsFriend(string name1, string name2)
        {
            bool isFriend = false;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                foreach(Friendship f in context.Friendships)
                {
                    if((f.User.Username == name1 && f.User1.Username == name2) || (f.User1.Username == name1 && f.User.Username == name2))
                    {
                        isFriend = true;
                        break;
                    }
                }
            }
            return isFriend;
        }
        private static bool containsUser(string username)
        {
            bool contains = false;
            using (ChatDatabaseEntities context = new ChatDatabaseEntities())
            {
                foreach(User u in context.Users)
                {
                    if(u.Username == username)
                    {
                        contains = true;
                        break;
                    }
                }
            }
            return contains;
        }

    }
}