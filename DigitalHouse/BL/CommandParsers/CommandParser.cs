using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DigitalHouse.Commands;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.CommandParsers
{
    public class CommandParser
    {
        private readonly IDeviceRepository mDeviceRepository;

        public CommandParser(IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
        }

        public ICommand ParseCommand(string message)
        {
            List<string> parameters = ParseStringToParameterList(message);

            switch (parameters.First())
            {
                case "listdevices":
                    return new ListDevices(mDeviceRepository, parameters.Skip(1));

                case "setdevicevalue":
                    return new SetDeviceValue(mDeviceRepository, parameters.Skip(1));

                default:
                    return new UnknownCommand(mDeviceRepository);
            }
        }

        private static List<string> ParseStringToParameterList(string messageToParse)
        {
            return messageToParse.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private Dictionary<string, ICommand> GetCommands(IDeviceRepository deviceRepository)
        {
            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
            foreach (var command in from t in Assembly.GetExecutingAssembly().GetTypes()
                                    where t.GetInterfaces().Contains(typeof(ICommand))
                                    select (ICommand)Activator.CreateInstance(t, deviceRepository))
            {
                commands.Add(command.GetName().ToLower(), command);
            }
            return commands;
        }
    }
}
