using System;
using System.Collections.Generic;
using System.Linq;
using DigitalHouse.BL.Commands;
using DigitalHouse.Commands;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.BL.CommandParsers
{
    public class CommandParser : ICommandParser
    {
        private readonly IDeviceRepository mDeviceRepository;
        private readonly IUserRepository mUserRepository;

        public CommandParser(IDeviceRepository deviceRepository, IUserRepository userRepository)
        {
            mDeviceRepository = deviceRepository;
            mUserRepository = userRepository;
        }

        public ICommand Parse(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return new UnknownCommand();
            }

            List<string> parameters = ParseStringToParameterList(message);

            switch (parameters.FirstOrDefault().ToLower())
            {
                case "listdevices":
                    return new ListDevices(mDeviceRepository);

                case "setdevicevalue":
                    return new SetDeviceValue(mDeviceRepository, parameters.Skip(1));

                case "login":
                    return new Login(mUserRepository, parameters.Skip(1));

                default:
                    return new UnknownCommand();
            }
        }

        private static List<string> ParseStringToParameterList(string messageToParse)
        {
            return messageToParse.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
