using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;
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

        public string ExecuteCommand(List<string> parameters)
        {
            ConcurrentDictionary<string, SettableDevice> devices = mDeviceRepository.GetDevices();

            string resp = "Devices: ";
            foreach (KeyValuePair<string, SettableDevice> settableDevice in devices)
            {
                resp += settableDevice.Key + ", State: " + settableDevice.Value.Value + " ";
            }

            return resp;
        }
    }
}
