using DigitalHouse.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Protocols;

namespace DigitalHouse.CommandExecutors
{
    public class CommandExecutor
    {
        private readonly CommandParser mCommandParser;

        public CommandExecutor(CommandParser commandParser, IMessageNotifier messageNotifier)
        {
            mCommandParser = commandParser;
            messageNotifier.OnMessageRecieved += ExecuteCommand;
        }

        public void ExecuteCommand(string message, IMessageResponseSender responseSender)
        {
            var command = mCommandParser.ParseCommand(message);
            
            if (command.CanExecute())
            {
                responseSender.SendMessage(command.Execute());
            }
        }
    }
}
