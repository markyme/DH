using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Communication.Protocols;

namespace DigitalHouse.Communication
{
    public interface INewSessionNotifier
    {
        event NewSessionEvent OnNewSession;
        void Start();
    }
}
