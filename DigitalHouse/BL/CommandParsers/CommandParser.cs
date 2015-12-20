using System;
using System.Collections.Generic;
using System.Linq;
using DigitalHouse.Commands;
using DigitalHouse.DB;

namespace DigitalHouse.BL.CommandParsers
{
    public class CommandParser : ICommandParser
    {
        private readonly IDeviceRepository mDeviceRepository;

        public CommandParser(IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
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
