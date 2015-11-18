using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public class HardCodedDataBase
    {
        public List<Switchable> switchableDevices = new List<Switchable>();
        public List<Settable> settableDevices = new List<Settable>();
        public HardCodedDataBase()
        {
            switchableDevices.Add(new Switchable("light", false));
            settableDevices.Add(new Settable("lamp", 0));
        }

        public string getDevicesList()
        {
            string devicesList = "";
            devicesList += "Switchable Devices: ";
            foreach (var switchableDevice in switchableDevices)
            {
                devicesList += "Name: " + switchableDevice.name + ", State: " + switchableDevice.state;
            }
            devicesList += "Settable Devices: ";
            foreach (var settableDevice in settableDevices)
            {
                devicesList += "Name: " + settableDevice.name + ", State: " + settableDevice.value;
            }
            
            return devicesList;
        }
    }
}
