using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB.UsersRepo
{
    public interface IUserRepository
    {
        void Login(string user);
        bool IsLoggedIn(string user);
        bool IsExists(string user);
    }
}
