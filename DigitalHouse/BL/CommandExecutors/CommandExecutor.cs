using DigitalHouse.BL.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.Session;

namespace DigitalHouse.BL.CommandExecutors
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly CommandParser mCommandParser;

        public CommandExecutor(CommandParser commandParser)
        {
            mCommandParser = commandParser;
        }

        public void ExecuteCommand(IHomeSession homeSession, string message)
        {
            var command = mCommandParser.Parse(message);
            
            if (command.CanExecute())
            {
                homeSession.Write(command.Execute());
            }
        }
    }
}
