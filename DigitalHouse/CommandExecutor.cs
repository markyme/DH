using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.Communication;
using DigitalHouse.DB;

namespace DigitalHouse
{
    public class CommandExecutor
    {
        List<Command> commands;
        private HardCodedDataBase dataBase;
       
        public CommandExecutor(HardCodedDataBase dataBase)
        {
            commands = GetInstances<Command>();
            this.dataBase = dataBase;
        }

        private static List<T> GetInstances<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }

        public void ExecuteCommand(Listener sender, MessageParameters parameters)
        {
            string response = commands.Find(x => x.GetName().Equals(parameters.message)).ExecuteCommand(dataBase);
            sender.sendMessageToClient(response);
        }
    }
}
