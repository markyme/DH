using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.BL.CommandExecutors;

namespace DigitalHouse.Communication.Session
{
    public class CommandNotifier
    {
        private readonly INewSessionNotifier mNewSessionNotifier;
        private readonly ICommandExecutor mCommandExecutor;

        public CommandNotifier(INewSessionNotifier notifier, ICommandExecutor commandExecutor)
        {
            mCommandExecutor = commandExecutor;
            mNewSessionNotifier = notifier;
            RegisterForNewSessions();
        }

        private void RegisterForNewSessions()
        {
            mNewSessionNotifier.OnNewSession += RegisterSessionForNewMessage;
        }

        private void RegisterSessionForNewMessage(IHomeSession homeSession)
        {
            homeSession.OnMessageRecieved += mCommandExecutor.ExecuteCommand;
        }
    }
}
