using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;

namespace DigitalHouse.Commands
{
    public class ListDevices : Command
    {
        public string GetName()
        {
            return "ListDevices";
        }

        public string ExecuteCommand(HardCodedDataBase dataBase)
        {
            return dataBase.getDevicesList();
        }
    }
}
