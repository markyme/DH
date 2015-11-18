using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using DigitalHouse.Communication;
using DigitalHouse.DB;

namespace DigitalHouse
{
    public class DigitalHouse
    {
        static void Main(string[] args)
        {
            HardCodedDataBase hardCodedDataBase = new HardCodedDataBase();
            CommandExecutor commandExecutor = new CommandExecutor(hardCodedDataBase);

            var listener = new Listener();
            listener.requestedCommand += commandExecutor.ExecuteCommand;
            listener.StartListener();
        }
    }
}
