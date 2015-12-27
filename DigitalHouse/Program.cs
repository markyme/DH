using System;
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
            var hardCodedUserRepository = new HardCodedUserRepository();

            var commandNotifier = new CommandNotifier(tcpNewSessionNotifier, hardCodedDeviceRepository, hardCodedUserRepository);
            
            tcpNewSessionNotifier.Start();
        }
    }


    // validate commands param count and type
/*    Class dependencies should be received from outside //inversion of control
tests for a couple of commands
LoginCommand should be responsible for logging in
Unknown command --> throw exception*/

    //TODO:  Error Handling - per module + global + client Lost = not ending
    //TODO:  Thread - async await
    // Exception from parser on empty command - catch on higher level

}
