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
using Newtonsoft.Json;

namespace DigitalHouse
{
    public class CommandExecutor
    {
        private CommandParser.CommandParser commandParser;

        public CommandExecutor(CommandParser.CommandParser commandParser, IListener listener)
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
