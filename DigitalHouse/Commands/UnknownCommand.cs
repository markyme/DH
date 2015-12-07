using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;
using Newtonsoft.Json;

namespace DigitalHouse.Commands
{
    class UnknownCommand : ICommand
    {
        private IDeviceRepository mDeviceRepository;

        public UnknownCommand(IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
        }

        public string GetName()
        {
            return "UnknownCommand";
        }

        public string ExecuteCommand(List<string> parameters)
        {
            return "UnknownCommand.";
        }
    }
}
