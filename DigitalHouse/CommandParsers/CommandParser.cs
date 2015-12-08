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
        readonly Dictionary<string,ICommand> mAvailableCommands;

        public CommandParser(IDeviceRepository deviceRepository)
        {
            mAvailableCommands = GetCommands(deviceRepository);
        }
        
        public ICommand ParseCommand(string message)
        {
            var parameters = ParseStringToParameterList(message);
            if (!mAvailableCommands.ContainsKey(parameters.First()))
            {
                return mAvailableCommands["unknowncommand"];
            }
            else
            {
                return new mAvailableCommands[parameters.First()]
                {
                    
                }
                // init command with params

            }
            



            return null;
        }

        private static IEnumerable<string> ParseStringToParameterList(string messageToParse)
        {
            foreach (var message in messageToParse.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries))
            {
                yield return message.ToLower();
            }
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
