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
            List<INewSessionNotifier> newSessionNotifiers = new List<INewSessionNotifier>
            {
                new TcpNewSessionNotifier()
            };
            
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();
            var commandParser = new CommandParser(hardCodedDeviceRepository);
            var commandExecutor = new CommandExecutor(commandParser);
            var commandNotifier = new CommandNotifier(newSessionNotifiers, commandExecutor);

            foreach (var newSessionNotifier in newSessionNotifiers)
            {
                newSessionNotifier.Start();
            }
        }
    }


    // Add isLoggedIn To Isession
    // Handle login state change

    //TODO:  Error Handling - per module + global + client Lost = not ending
    //TODO:  Extendable - Different Listeners (communication, JSON commands?) 
    //TODO:  Thread - move to newer way

    //  Naming - Correct and Related
    //  Watch for unsafe operations
}
