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
    public class CommandParser
    {
        readonly Dictionary<string,ICommand> commands;

        public CommandParser(IDeviceRepository deviceRepository)
        {
            commands = GetCommands(deviceRepository);
        }
        
        public ICommand ParseCommand(string message)
        {
            if (commands.ContainsKey(message.ToLower())) return commands[message];
            return commands["unknowncommand"];
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
