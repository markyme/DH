using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.CommandParsers;
using DigitalHouse.Commands;
using DigitalHouse.Communication;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;
using Newtonsoft.Json;

namespace DigitalHouse
{
    public class CommandExecutor
    {
        private readonly CommandParser mCommandParser;

        public CommandExecutor(CommandParser commandParser, IListener listener)
        {
            mCommandParser = commandParser;
            listener.OnMessageRecieved += ExecuteCommand;
        }

        public void ExecuteCommand(string message, CommunicationResponseDelegate response)
        {
            var command = mCommandParser.ParseCommand(message);
            var parameters = mCommandParser.ParseCommandParams(message);
            response(command.ExecuteCommand(parameters));
        }
    }
}
