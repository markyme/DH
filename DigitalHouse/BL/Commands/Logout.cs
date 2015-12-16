using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;

namespace DigitalHouse.BL.Commands
{
    public class Logout : ICommand
    {
        private IHomeSession mSession;

        public Logout(IHomeSession homeSession)
        {
            mSession = homeSession;
        }

        public string GetName()
        {
            return "Login";
        }

        public string Execute()
        {
            mSession.Logout();
            return "OK";
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
