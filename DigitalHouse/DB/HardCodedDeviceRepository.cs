using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public class HardCodedDeviceRepository : IDeviceRepository
    {
        public List<SettableDevice> SettableDevices = new List<SettableDevice>();
        
        public HardCodedDeviceRepository()
        {
            SettableDevices.Add(new SettableDevice("light", 100));
        }

        public IEnumerable<SettableDevice> GetDevices()
        {
            return SettableDevices;
        }
    }
}
