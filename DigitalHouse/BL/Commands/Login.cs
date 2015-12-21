using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.BL.Commands
{
    public class Login : ICommand
    {
        private readonly string mUserToLogin;
        private readonly IUserRepository mUserRepository;

        public Login(IUserRepository userRepository, IEnumerable<string> parameters)
        {
            mUserRepository = userRepository;
            mUserToLogin = parameters.ElementAtOrDefault(0);
        }

        public string GetName()
        {
            return "Login";
        }

        public string Execute()
        {
            if (!mUserRepository.IsExists(mUserToLogin)) return "false";
            mUserRepository.Login(mUserToLogin);
            
            return "true";
        }

        public bool CanExecute()
        {
            return !String.IsNullOrEmpty(mUserToLogin);
        }
    }
}
