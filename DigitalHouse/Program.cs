
using DigitalHouse.CommandExecutors;
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
            var hardCodedUserRepository = new HardCodedUserRepository();
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();
            var notifier = new TcpMessageNotifier();
            var commandParser = new CommandParser(hardCodedDeviceRepository);
            var commandExecutor = new CommandExecutor(commandParser, notifier);
            notifier.Start();
        }
    }


    //TODO:  Error Handling - per module + global + client Lost = not ending

    //TODO:  Login - SessionManager?
    //TODO:  Extendable - Different Listeners (communication, JSON commands?) 
    //TODO:  Unit Tests
    //TODO:  Thread - move to newer way
    // separate comm from logic

    //  Naming - Correct and Related
    //  Watch for unsafe operations

}
