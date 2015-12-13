using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;

namespace DigitalHouse.Commands
{
    public class UnknownCommand : ICommand
    {
        private IDeviceRepository mDeviceRepository;

        public UnknownCommand(IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
        }

        public int NeededParamCount { get; private set; }

        public string GetName()
        {
            return "UnknownCommand";
        }

        public string Execute()
        {
            return "UnknownCommand.";
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
