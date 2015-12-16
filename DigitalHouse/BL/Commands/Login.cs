using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;

namespace DigitalHouse.BL.Commands
{
    public class Login : ICommand
    {
        private IHomeSession mSession;

        public Login(IHomeSession homeSession)
        {
            mSession = homeSession;
        }

        public string GetName()
        {
            return "Login";
        }

        public string Execute()
        {
            mSession.Login();
            return "OK";
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
