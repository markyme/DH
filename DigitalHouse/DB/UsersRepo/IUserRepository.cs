using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB.UsersRepo
{
    public interface IUserRepository
    {
        void Login(string userToLogin);
        bool IsLoggedIn(string userToCheck);
        void Logout(string userToLogout);
    }
}
