using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IUser user = new UserServiceProxy())
            {
                User us1 = user.GetUser("nast");
                Console.WriteLine(us1.Name);
            }

            Console.Read();
        }
    }
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

    }
    class UserContext : DbContext
    {
        public UserContext() : base("name=UserContext")
        {

        }
        public DbSet<User> Users { get; set; }
    }

    interface IUser : IDisposable
    {
        User GetUser(string username);
    }

    class UserService : IUser
    {
        UserContext db;
        public UserService()
        {
            db = new UserContext();
        }
        public User GetUser(string username)
        {
            return db.Users.FirstOrDefault(p => p.Username == username);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    class UserServiceProxy : IUser
    {
        List<User> users;
        UserService bookStore;
        public UserServiceProxy()
        {
            users = new List<User>();
        }
        public User GetUser(string username)
        {
            User u = users.FirstOrDefault(p => p.Username == username);
            if (u == null)
            {
                if (bookStore == null)
                    bookStore = new UserService();
                u = bookStore.GetUser(username);
                users.Add(u);
            }
            return u;
        }

        public void Dispose()
        {
            if (bookStore != null)
                bookStore.Dispose();
        }
    }
}
