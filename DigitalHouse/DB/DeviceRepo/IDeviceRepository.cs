using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public interface IDeviceRepository
    {
        ConcurrentDictionary<string, SettableDevice> GetDevices();
        void SetDeviceValue(string deviceName, int value);
    }
}
