using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;

namespace DigitalHouse
{
    public class CommandNotifier
    {
        private readonly INewSessionNotifier mNewSessionSessionNotifier;
        private readonly IDeviceRepository mDeviceRepository;

        public CommandNotifier(INewSessionNotifier sessionNotifier, IDeviceRepository deviceRepository)
        {
            mDeviceRepository = deviceRepository;
            mNewSessionSessionNotifier = sessionNotifier;

            RegisterForNewSessions();
        }

        private void RegisterForNewSessions()
        {
            mNewSessionSessionNotifier.OnNewSession += NotifyOnCommand;
        }

        private void NotifyOnCommand(IHomeSession homeSession)
        {
            homeSession.OnMessageRecieved += new CommandExecutor(mDeviceRepository).ExecuteCommand;
        }
    }
}
