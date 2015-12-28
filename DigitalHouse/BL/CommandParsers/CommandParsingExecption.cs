using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.BL.CommandExecutors
{
    class CommandParsingExecption : Exception
    {
        public CommandParsingExecption() { }

        public CommandParsingExecption(string message) :base(message) {}
    }
}
