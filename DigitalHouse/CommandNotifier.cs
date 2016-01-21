using System;
using System.Text;
using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.BL.CommandParsers;
using DigitalHouse.Communication;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse
{
    public class CommandNotifier
    {
        private readonly INewSessionNotifier mNewSessionSessionNotifier;
        private readonly IDeviceRepository mDeviceRepository;
        private readonly IUserRepository mUserRepository;

        public CommandNotifier(
                  INewSessionNotifier sessionNotifier,
                  IDeviceRepository deviceRepository,
                  IUserRepository userRepository)
        {
            mDeviceRepository = deviceRepository;
            mUserRepository = userRepository;
            mNewSessionSessionNotifier = sessionNotifier;

            RegisterForNewSessions();
        }

        private void RegisterForNewSessions()
        {
            mNewSessionSessionNotifier.OnNewSession += HandleSessionCommunication;
        }

        private void HandleSessionCommunication(IHomeSession homeSession)
        {
            using (homeSession.getOnMessageRecievedObservable().Subscribe(
                onNext: msg =>
                    {
                        var commandParser = new CommandParser(mDeviceRepository, mUserRepository, homeSession);
                        var commandExecutor = new CommandExecutor(commandParser);
                        var resp = commandExecutor.ExecuteCommand(homeSession, msg);

                        homeSession.Write(resp);
                    }, 
                 onError: (error) => { Console.WriteLine("error occured: " + error); }))
            {

            }
        }
    }
}
