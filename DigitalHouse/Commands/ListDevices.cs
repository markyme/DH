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
        private IDeviceRepository DeviceRepository;
        public ListDevices(IDeviceRepository deviceRepository)
        {
            this.DeviceRepository = deviceRepository;
        }
        public string GetName()
        {
            return "ListDevices";
        }

        public string ExecuteCommand()
        {
            return DeviceRepository.GetDevices();
        }
    }
}
