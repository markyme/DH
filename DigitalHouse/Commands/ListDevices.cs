using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;

namespace DigitalHouse.Commands
{
    public class ListDevices : ICommand
    {
        public string GetName()
        {
            return "ListDevices";
        }

        public string ExecuteCommand(IDeviceRepository deviceRepository)
        {
            return deviceRepository.GetDevices();
        }
    }
}
