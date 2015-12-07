using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB.UsersRepo
{
    public class User
    {
        public string Name;
        public bool IsLoggedIn;

        public User(string name, bool isLoggedIn = false)
        {
            Name = name;
            IsLoggedIn = isLoggedIn;
        }
    }
}
