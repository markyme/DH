using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalHouse.Communication
{
    public class TcpListener : IListener
    {
        public event CommunicationRequestEvent OnMessageRecieved;
        private readonly System.Net.Sockets.TcpListener mListener;

        public TcpListener()
        {
            mListener = new System.Net.Sockets.TcpListener(IPAddress.Any, 8001);
        }

        public void Listen()
        {
            mListener.Start();
            Console.WriteLine("Waiting for a connection.....");
            while (true)
            {
                // If there's someone waiting for connecting
                if (mListener.Pending())
                {
                    var socket = mListener.AcceptSocket();
                    new Thread(() => HandleSingleRequest(socket)).Start();
                }
            }
        }

        private void HandleSingleRequest(Socket socket)
        {
            Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);

            while (socket.Connected)
            {
                try
                {
                    var message = GetMessageFromClient(socket);

                    // PUTTY sends empty message
                    if (message.Equals("\r\n")) { continue; }

                    Console.WriteLine("Recieved: " + message);
                    OnMessageRecieved(message, (x) => socket.Send(Encoding.ASCII.GetBytes(x)));
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Warning: connection failed: " + exception);
                }
            }
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
