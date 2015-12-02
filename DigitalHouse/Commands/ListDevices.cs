using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;
using Newtonsoft.Json;

namespace DigitalHouse.Commands
{
    public class ListDevices : ICommand
    {
        private readonly IDeviceRepository mDeviceRepository;
        public ListDevices(IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
        }

        public string GetName()
        {
            return "ListDevices";
        }

        public string ExecuteCommand()
        {
            IEnumerable<SettableDevice> devices = mDeviceRepository.GetDevices();

            string resp = "Devices: ";
            foreach (var settableDevice in devices)
            {
                resp += settableDevice.name + ", State: " + settableDevice.value + " ";
            }

            return resp;
        }
    }
}
