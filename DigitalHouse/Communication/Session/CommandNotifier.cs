using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.DB;

namespace DigitalHouse.Communication.Session
{
    public class CommandNotifier
    {
        private readonly INewSessionNotifier mNewSessionNotifier;
        private readonly IDeviceRepository mDeviceRepository;

        public CommandNotifier(INewSessionNotifier notifier, IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
            mNewSessionNotifier = notifier;

            RegisterForNewSessions();
        }

        private void RegisterForNewSessions()
        {
            //mNewSessionNotifier.OnNewSession += (newSession) => newSession.OnMessageRecieved += new CommandExecutor(mDeviceRepository, newSession).ExecuteCommand;
            mNewSessionNotifier.OnNewSession += NotifyOnCommand;
        }

        private void NotifyOnCommand(IHomeSession homeSession)
        {
            homeSession.OnMessageRecieved += new CommandExecutor(mDeviceRepository, homeSession).ExecuteCommand;
        }
    }
}
