using System;
using System.Collections.Generic;
using System.Linq;
using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.BL.Commands;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.BL.CommandParsers
{
    public class CommandParser : ICommandParser
    {
        private readonly IDeviceRepository mDeviceRepository;
        private readonly IUserRepository mUserRepository;
        private readonly ILoginActions mLoginActions;

        public CommandParser(
            IDeviceRepository deviceRepository,
            IUserRepository userRepository,
            ILoginActions loginActions)
        {
            mDeviceRepository = deviceRepository;
            mUserRepository = userRepository;
            mLoginActions = loginActions;
        }

        public ICommand Parse(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                throw new CommandParsingExecption("Empty Command");
            }

            List<string> parameters = ParseStringToParameterList(message);

            switch (parameters.FirstOrDefault().ToLower())
            {
                case "listdevices":
                    return new ListDevices(mDeviceRepository);

                case "setdevicevalue":
                    return new SetDeviceValue(mDeviceRepository, parameters.Skip(1));

                case "login":
                    return new Login(mUserRepository, mLoginActions, parameters.Skip(1));

                default:
                    return new UnknownCommand();
            }
        }

        private static List<string> ParseStringToParameterList(string messageToParse)
        {
            return messageToParse.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
