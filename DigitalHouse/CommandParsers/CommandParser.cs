using System;
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
        readonly Dictionary<string,ICommand> mCommands;

        public CommandParser(IDeviceRepository deviceRepository)
        {
            mCommands = GetCommands(deviceRepository);
        }
        
        public ICommand ParseCommand(string message)
        {
            string messageToParse = message;
            List<string> parameters = messageToParse.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).ToList();
            
            return mCommands.ContainsKey(parameters.First().ToLower()) ? mCommands[parameters.First().ToLower()] : mCommands["unknowncommand"];
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

        public List<string> ParseCommandParams(string message)
        {
            List<string> parameters = message.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).ToList();
            parameters.RemoveAt(0);
            return parameters;
        }
    }
}
