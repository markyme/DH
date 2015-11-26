using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.DB;

namespace DigitalHouse.CommandParser
{
    class StringCommandParser : ICommandParser
    {
        List<ICommand> commands;

        public StringCommandParser(IDeviceRepository deviceRepository)
        {
            commands = GetCommands(deviceRepository);
        }

        private static List<ICommand> GetCommands(IDeviceRepository deviceRepository)
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                   where t.GetInterfaces().Contains(typeof(ICommand))
                    select (ICommand)Activator.CreateInstance(t, deviceRepository)).ToList();
        }

        public ICommand ParseCommand(string message)
        {
            return commands.Find(x => x.GetName().Equals(message));
        }
    }
}
