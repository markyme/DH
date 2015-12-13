using DigitalHouse.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.Session;

namespace DigitalHouse.BL.CommandExecutors
{
    public class CommandExecutor
    {
        private readonly CommandParser mCommandParser;

        public CommandExecutor(CommandParser commandParser, INewSessionNotifier newSessionNotifier)
        {
            mCommandParser = commandParser;
            newSessionNotifier.OnNewSession += RegisterSession;
        }

        public void RegisterSession(IHomeSession homeSession)
        {
            homeSession.OnMessageRecieved += ExecuteCommand;
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
