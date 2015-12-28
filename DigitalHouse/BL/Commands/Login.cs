using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.BL.Commands
{
    public class Login : ICommand
    {
        private readonly string mUserToLogin;
        private readonly IUserRepository mUserRepository;
        private readonly ILoginActions mHomeSession;
        private readonly IEnumerable<string> mParameters;

        public Login(IUserRepository userRepository, ILoginActions homeSession, IEnumerable<string> parameters)
        {
            mUserRepository = userRepository;
            mHomeSession = homeSession;
            mParameters = parameters;
            mUserToLogin = mParameters.ElementAtOrDefault(0);
        }

        public string GetName()
        {
            return "Login";
        }

        public string Execute()
        {
            mHomeSession.Login();
            return "OK";
        }

        public bool CanExecute()
        {
            return !String.IsNullOrEmpty(mUserToLogin) && mParameters.Count() < 2 && mUserRepository.IsExists(mUserToLogin);
        }
    }
}
