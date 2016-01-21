using System;
using DigitalHouse.BL.CommandParsers;
using DigitalHouse.BL.Commands;
using DigitalHouse.Commands;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.BL.CommandExecutors
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandParser mCommandParser;

        public CommandExecutor(ICommandParser commandParser)
        {
            mCommandParser = commandParser;
        }

        public string ExecuteCommand(IHomeSession homeSession, string message)
        {
            ICommand command;

            try
            {
                command = mCommandParser.Parse(message);
            }
            catch (CommandParsingExecption execption)
            {
                return execption.Message;
            }

            if (!homeSession.IsLoggedIn() && command.GetType() != typeof (Login))
            {
                return "Not Logged In";
            }

            //homeSession.Write(command.CanExecute() ? command.Execute() : "Cannot Execute Command");
            return (command.CanExecute() ? command.Execute() : "Cannot Execute Command");
        }
    }
}
