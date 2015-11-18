using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    class User
    {
        public string userName;
        public string password;

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
