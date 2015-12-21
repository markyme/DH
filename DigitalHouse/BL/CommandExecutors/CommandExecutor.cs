using System;
using DigitalHouse.BL.CommandParsers;
using DigitalHouse.BL.Commands;
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

        public CommandExecutor(IDeviceRepository deviceRepository, IUserRepository userRepository)
        {
            mCommandParser = new CommandParser(deviceRepository, userRepository);
        }

        public void ExecuteCommand(IHomeSession homeSession, string message)
        {
            var command = mCommandParser.Parse(message);

            if (command.GetType() == typeof (Login))
            {
                if (command.CanExecute())
                {
                    var response = command.Execute();
                    if (Boolean.Parse(response).Equals(true))
                    {
                        homeSession.Login();
                        return;
                    }
                }
                homeSession.Write("Login Failed");
                return;
            }

            if (!homeSession.IsLoggedIn())
            {
                homeSession.Write("Not Logged In");
                return;
            }

            homeSession.Write(command.CanExecute() ? command.Execute() : "Cannot Execute Command");
        }
    }
}
