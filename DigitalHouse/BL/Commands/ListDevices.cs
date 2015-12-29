using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

            var result = "";

            foreach (var device in devices)
            {
                result += (device.Key + ", State: " + device.Value.Value);

                if (!devices.Last().Equals(device)) result += Environment.NewLine;
            }

            return result;
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
