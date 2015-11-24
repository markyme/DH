using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;

namespace DigitalHouse.CommandParser
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string message);
    }
}
