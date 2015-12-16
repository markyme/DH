using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.Commands
{
    public class SetDeviceValue : ICommand
    {
        private readonly IDeviceRepository mDeviceRepository;
        private readonly IHomeSession mHomeSession;
        private string mDeviceToSet;
        private string mValueToSet;

        public SetDeviceValue(IDeviceRepository deviceRepository, IHomeSession homeSession, IEnumerable<string> parameters)
        {
            mDeviceRepository = deviceRepository;
            mHomeSession = homeSession;
            mDeviceToSet = parameters.ElementAtOrDefault(0);
            mValueToSet = parameters.ElementAtOrDefault(1);
        }

        public string GetName()
        {
            return "SetDeviceValue";
        }

        public string Execute()
        {
            mDeviceRepository.SetDeviceValue(mDeviceToSet, int.Parse(mValueToSet));
            return "OK";
        }

        public bool CanExecute()
        {
            return mHomeSession.IsLoggedIn();
        }
    }
}

