using DigitalHouse.CommandExecutors;
using DigitalHouse.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.TCP;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse
{
    public class DigitalHouse
    {
        static void Main(string[] args)
        {
            var hardCodedUserRepository = new HardCodedUserRepository();
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();
            var listener = new TcpMessageNotifier();
            var commandParser = new CommandParser(hardCodedDeviceRepository);
            var commandExecutor = new CommandExecutor(commandParser, listener);
            listener.Start();
        }
    }


    //TODO:  Switch case - delete the reflection
    //TODO:  Error Handling - per module + global + client Lost = not ending

    //TODO:  Login - SessionManager?
    //TODO:  Extendable - Different Listeners (communication, JSON commands?) 
    //TODO:  Unit Tests
    //TODO:  Thread - move to newer way
    
    //  Naming - Correct and Related
    //  Watch for unsafe operations
    
}
