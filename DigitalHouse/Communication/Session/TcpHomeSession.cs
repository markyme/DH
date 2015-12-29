using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.TCP;

namespace DigitalHouse.Communication.Session
{
    public class TcpHomeSession : IHomeSession
    {
        public event NewMessageRecievedEvent OnMessageRecieved;

        private bool mIsLoggedIn;

        public bool IsLoggedIn() { return mIsLoggedIn; }

        public void Login() { mIsLoggedIn = true; }

        private readonly Socket mSocket;

        public TcpHomeSession(Socket socket)
        {
            mSocket = socket;
        }

        public void Listen()
        {
            while (mSocket.Connected)
            {
                try
                {
                    var message = GetMessageFromClient(mSocket);
                    if (message.Equals("\r\n")) { continue; }
                    Console.WriteLine("Recieved: " + message);

                    OnMessageRecieved(this, message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Warning: connection failed: " + exception);
                    mSocket.Close();
                }
            }
        }

        public void Write(string message)
        {
            mSocket.Send(Encoding.ASCII.GetBytes(message + "\n"));
        }

        private static string GetMessageFromClient(Socket socket)
        {
            byte[] receivingBuffer = new byte[100];
            int k = socket.Receive(receivingBuffer);

            String message = "";
            for (var i = 0; i < k; i++)
            {
                message += Convert.ToChar(receivingBuffer[i]);
            }
            return message;
        }
    }
}
