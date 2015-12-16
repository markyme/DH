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
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();

            var commandNotifier = new CommandNotifier(tcpNewSessionNotifier, hardCodedDeviceRepository);

            tcpNewSessionNotifier.Start();
        }
    }

    // command executer will check for logged in - parser and commands doest know ihomesession
    // Cover all flows and commands on unittests - use nunit testcase
    

    //TODO:  Error Handling - per module + global + client Lost = not ending
    //TODO:  Extendable - Different Listeners (communication, JSON commands?) 
    //TODO:  Thread - move to newer way

    //  Naming - Correct and Related
    //  Watch for unsafe operations
}
