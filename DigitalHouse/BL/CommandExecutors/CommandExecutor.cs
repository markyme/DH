using DigitalHouse.BL.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;

namespace DigitalHouse.BL.CommandExecutors
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandParser mCommandParser;

        public CommandExecutor(IDeviceRepository deviceRepository)
        {
            mCommandParser = new CommandParser(deviceRepository);
        }

        public void ExecuteCommand(IHomeSession homeSession, string message)
        {



            if (message == "login")
            {
                homeSession.Login();
                return;
            }

            if (!homeSession.IsLoggedIn())
            {
                homeSession.Write("Not Logged in");
                return;
            }

            var command = mCommandParser.Parse(message);
            homeSession.Write(command.CanExecute() ? command.Execute() : "Cannot Execute Command");
        }
    }
}
