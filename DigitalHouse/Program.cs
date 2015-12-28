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


//LoginCommand should be responsible for logging in

//Error Handling - per module + global

}
