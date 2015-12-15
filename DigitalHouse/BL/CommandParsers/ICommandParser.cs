using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;

namespace DigitalHouse.BL.CommandParsers
{
    public interface ICommandParser
    {
        ICommand Parse(string message);
    }
}
