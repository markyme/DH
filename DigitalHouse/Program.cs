using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.CommandParsers;
using DigitalHouse.Communication.TCP;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse
{
    public class DigitalHouse
    {
        static void Main(string[] args)
        {
            //var hardCodedUserRepository = new HardCodedUserRepository();
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();
            
            var notifier = new TcpNewSessionNotifier();
            var commandParser = new CommandParser(hardCodedDeviceRepository);
            var commandExecutor = new CommandExecutor(commandParser, notifier);

            notifier.Start();
        }
    }


    // Split command exeuter to SessionManagerType and Executer
    // Add isLoggedIn To Isession
    // Handle login state change

    //TODO:  Error Handling - per module + global + client Lost = not ending
    //TODO:  Extendable - Different Listeners (communication, JSON commands?) 
    //TODO:  Unit Tests
    //TODO:  Thread - move to newer way

    //  Naming - Correct and Related
    //  Watch for unsafe operations

    /*
     * ParseCommand
     * -------------
       unknown command name
       command name casing
       no match in parameter count
       null
       empty

       NUnit
       FakeItEasy
     */
}
