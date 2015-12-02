using System;
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
            var hardCodedDeviceRepository = new HardCodedDeviceRepository();
            var listener = new TCPListener();
            var commandParser = new CommandParser.CommandParser(hardCodedDeviceRepository);
            CommandExecutor commandExecutor = new CommandExecutor(commandParser, listener);
            listener.Listen();
        }
    }
}
