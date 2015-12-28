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

        public void ExecuteCommand(IHomeSession homeSession, string message)
        {
            ICommand command = null;

            try
            {
                command = mCommandParser.Parse(message);
            }
            catch (CommandParsingExecption execption)
            {
                // Who knows about this?
                homeSession.Write(execption.Message);
            }

            if (command == null)
            {
                return;
            }

            if (!homeSession.IsLoggedIn() && command.GetType() != typeof (Login))
            {
                homeSession.Write("Not Logged In");
                return;
            }

            homeSession.Write(command.CanExecute() ? command.Execute() : "Cannot Execute Command");
        }
    }
}
