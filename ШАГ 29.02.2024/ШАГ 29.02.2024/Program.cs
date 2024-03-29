using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_29._02._2024
{
    internal class Program
    {
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsAuthenticated { get; set; }
        }
        public delegate void AuthorizationHandler(User user);
        public class AuthorizationSystem
        {
            public event AuthorizationHandler UserAuthorized;
            public event AuthorizationHandler UserBlocked;
            private List<User> users;
            public AuthorizationSystem()
            {
                users = new List<User>();
            }
            public void AddUser(User user)
            {
                users.Add(user);
            }
            public void RemoveUser(User user)
            {
                users.Remove(user);
            }
            public void AuthenticateUser(string username, string password)
            {
                User user = users.Find(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    user.IsAuthenticated = true;
                    OnUserAuthorized(user);
                }
                else
                {
                    Console.WriteLine($"Не вдалося автентифікувати користувача {username}.");
                    BlockUser(username);
                }
            }
            public void BlockUser(string username)
            {
                User user = users.Find(u => u.Username == username);
                if (user != null)
                {
                    user.IsAuthenticated = false;
                    OnUserBlocked(user);
                }
            }
            protected virtual void OnUserAuthorized(User user)
            {
                UserAuthorized?.Invoke(user);
            }
            protected virtual void OnUserBlocked(User user)
            {
                UserBlocked?.Invoke(user);
            }
            public void PrintUsers()
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"Ім'я користувача: {user.Username}, Автентифіковано: {user.IsAuthenticated}");
                }
            }
        }
        static void Main(string[] args)
        {
            AuthorizationSystem authSystem = new AuthorizationSystem();
            User user1 = new User { Username = "user1", Password = "password1" };
            User user2 = new User { Username = "user2", Password = "password2" };
            authSystem.AddUser(user1);
            authSystem.AddUser(user2);
            authSystem.UserAuthorized += OnUserAuthorized;
            authSystem.UserBlocked += OnUserBlocked;
            authSystem.AuthenticateUser("user1", "password1");
            authSystem.AuthenticateUser("user2", "wrongpassword");
            authSystem.RemoveUser(user1);
            authSystem.BlockUser("user2");
            authSystem.PrintUsers();
        }
        static void OnUserAuthorized(User user)
        {
            Console.WriteLine($"Користувач {user.Username} було успішно автентифіковано.");
        }
        static void OnUserBlocked(User user)
        {
            Console.WriteLine($"Користувач {user.Username} було заблоковано через невдалі спроби автентифікації.");
        }
    }
}
