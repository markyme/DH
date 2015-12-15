using System.Collections.Generic;
using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.BL.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Session;
using DigitalHouse.Communication.TCP;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse
{
    public class DigitalHouse
    {

        static void Main(string[] args)
        {
            var tcpNewSessionNotifier = new TcpNewSessionNotifier();
            List<INewSessionNotifier> newSessionNotifiers = new List<INewSessionNotifier>
            {
                tcpNewSessionNotifier
            };
            
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();
            var commandParser = new CommandParser(hardCodedDeviceRepository);
            var commandExecutor = new CommandExecutor(commandParser);
            
            var commandNotifier = new CommandNotifier(newSessionNotifiers, commandExecutor);
            //tcpNewSessionNotifier.OnNewSession += x => x.OnMessageRecieved += new CommandExecutor(commandParser).ExecuteCommand;
            
            foreach (var newSessionNotifier in newSessionNotifiers)
            {
                newSessionNotifier.Start();
            }
        }
    }

    // Cover all flows and commands on unittests - use nunit testcase
    // Refactor code to be disposable
    // Login command - will depend on Isession

    //TODO:  Error Handling - per module + global + client Lost = not ending
    //TODO:  Extendable - Different Listeners (communication, JSON commands?) 
    //TODO:  Thread - move to newer way

    //  Naming - Correct and Related
    //  Watch for unsafe operations
}
