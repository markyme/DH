using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB.UsersRepo
{
    public class HardCodedUserRepository : IUserRepository
    {
        private ConcurrentDictionary<string, User> mUsers = new ConcurrentDictionary<string, User>();

        public HardCodedUserRepository()
        {
            mUsers.TryAdd("markTheCool", new User("markTheCool"));
            mUsers.TryAdd("markTheGreat", new User("markTheGreat"));
        }

        public void Login(string userToLogin)
        {
            mUsers[userToLogin].IsLoggedIn = true;
        }

        public bool IsLoggedIn(string userToCheck)
        {
            return mUsers[userToCheck].IsLoggedIn;
        }

        public void Logout(string userToLogout)
        {
            mUsers[userToLogout].IsLoggedIn = false;
        }
    }
}
