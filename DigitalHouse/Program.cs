using DigitalHouse.CommandParsers;
using DigitalHouse.Communication;
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
            var listener = new TcpListener();
            var commandParser = new CommandParser(hardCodedDeviceRepository);
            var commandExecutor = new CommandExecutor(commandParser, listener);
            listener.Listen();
        }
    }


    //TODO: 1. Login - SessionManager?
    //TODO: 2. Separate everything to different projects
    //TODO: 3. Extendable - Different Listeners (communication, JSON commands?)
}
