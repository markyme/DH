using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

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

        public string Execute()
        {
            ConcurrentDictionary<string, SettableDevice> devices = mDeviceRepository.GetDevices();

            string resp = "Devices: ";
            foreach (KeyValuePair<string, SettableDevice> settableDevice in devices)
            {
                resp += settableDevice.Key + ", State: " + settableDevice.Value.Value + " ";
            }

            return resp;
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
