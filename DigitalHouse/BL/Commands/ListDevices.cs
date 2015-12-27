using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using DigitalHouse.Commands;
using DigitalHouse.DB;

namespace DigitalHouse.BL.Commands
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
            var devices = mDeviceRepository.GetDevices();

            if (devices.IsEmpty)
            {
                return "No Devices Found";
            }

            string deviceList = "Devices:" + Environment.NewLine;
            foreach (var settableDevice in devices)
            {
                deviceList += settableDevice.Key + ", State: " + settableDevice.Value.Value + Environment.NewLine;
            }
            
            return deviceList;
        }
        
        public bool CanExecute()
        {
            return true;
        }
    }
}
