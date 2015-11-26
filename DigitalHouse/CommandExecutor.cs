using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.CommandParser;
using DigitalHouse.Commands;
using DigitalHouse.Communication;
using DigitalHouse.DB;

namespace DigitalHouse
{
    public class CommandExecutor
    {
        private ICommandParser commandParser;

        public CommandExecutor(ICommandParser commandParser, IListener listener)
        {
            this.commandParser = commandParser;
            listener.OnMessageRecieved += ExecuteCommand;
        }

        public void ExecuteCommand(IListener sender, MessageParameters parameters)
        {
            ICommand command = commandParser.ParseCommand(parameters.message);
            sender.Send(command.ExecuteCommand());
        }
    }
}
