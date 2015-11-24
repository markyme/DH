﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.CommandParser;
using DigitalHouse.Commands;
using DigitalHouse.Communication;
using DigitalHouse.DB;

namespace DigitalHouse
{
    public class DigitalHouse
    {
        static void Main(string[] args)
        {
            IDeviceRepository hardCodedDeviceRepository = new HardCodedDeviceRepository();
            IListener tcpListener = new TCPListener();
            ICommandParser commandParser = new StringCommandParser();

            CommandExecutor commandExecutor = new CommandExecutor(hardCodedDeviceRepository, commandParser);
            commandExecutor.SubscribeToListener(tcpListener);
            
      
        }
    }
}