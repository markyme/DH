using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public class HardCodedDeviceRepository : IDeviceRepository
    {
        ConcurrentDictionary<string, SettableDevice> mSettableDevices = new ConcurrentDictionary<string, SettableDevice>();
        
        public HardCodedDeviceRepository()
        {
            mSettableDevices.TryAdd("light", new SettableDevice("light", 100));
            mSettableDevices.TryAdd("airConditioner", new SettableDevice("airConditioner", 100));
        }

        public ConcurrentDictionary<string, SettableDevice> GetDevices()
        {
            return mSettableDevices;
        }

        public void SetDeviceValue(string deviceName, int value)
        {
            mSettableDevices[deviceName].Value = value;
        }
    }
}
