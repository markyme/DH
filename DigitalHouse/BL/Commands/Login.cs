using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;

namespace DigitalHouse.BL.Commands
{
    public class Login : ICommand
    {
        public string GetName()
        {
            return "Login";
        }

        public string Execute()
        {
            throw new NotImplementedException();
        }

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }
    }
}
