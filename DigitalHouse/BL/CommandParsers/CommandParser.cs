using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DigitalHouse.BL.Commands;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;

namespace DigitalHouse.BL.CommandParsers
{
    public class CommandParser : ICommandParser
    {
        private readonly IDeviceRepository mDeviceRepository;
        private readonly IHomeSession mHomeSession;

        public CommandParser(IDeviceRepository deviceRepository, IHomeSession homeSession)
        {
            mDeviceRepository = deviceRepository;
            mHomeSession = homeSession;
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
                    return new ListDevices(mDeviceRepository, mHomeSession);

                case "setdevicevalue":
                    return new SetDeviceValue(mDeviceRepository, mHomeSession, parameters.Skip(1));

                case "login":
                    return new Login(mHomeSession);

                case "logout":
                    return new Logout(mHomeSession);

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
