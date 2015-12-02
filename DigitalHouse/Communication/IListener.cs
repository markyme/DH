using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.Communication
{
    public interface IListener
    {
        event CommunicationProtocalEvent OnMessageRecieved;
        void Send(string message);
        void Listen();
    }
}
