using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Communication.Session;

namespace DigitalHouse.BL.CommandExecutors
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(IHomeSession homeSession, string message);
    }
}
