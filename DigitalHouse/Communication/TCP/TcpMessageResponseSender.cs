using DigitalHouse.Communication.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.Communication.TCP
{
    public class TcpMessageResponseSender : IMessageResponseSender
    {
        private readonly Socket mSocket;

        public TcpMessageResponseSender(Socket socket)
        {
            mSocket = socket;
        }

        public void SendMessage(string message)
        {
            mSocket.Send(Encoding.ASCII.GetBytes(message));
        }
    }
}
