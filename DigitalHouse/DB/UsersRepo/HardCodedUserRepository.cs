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
            mUsers.TryAdd("mark", new User("mark"));
            mUsers.TryAdd("marky", new User("marky"));
        }

        public bool IsExists(string user)
        {
            return mUsers.ContainsKey(user);
        }
    }
}
