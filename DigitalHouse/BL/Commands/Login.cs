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
        private readonly IEnumerable<string> mParameters;

        public Login(IUserRepository userRepository, IEnumerable<string> parameters)
        {
            mUserRepository = userRepository;
            mParameters = parameters;
            mUserToLogin = mParameters.ElementAtOrDefault(0);
        }

        public string GetName()
        {
            return "Login";
        }

        public string Execute()
        {
            return mUserRepository.IsExists(mUserToLogin) ? "true" : "false";
        }

        public bool CanExecute()
        {
            return !String.IsNullOrEmpty(mUserToLogin) && mParameters.Count() < 2;
        }
    }
}
