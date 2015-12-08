using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DigitalHouse.Communication.Protocols;

namespace DigitalHouse.Communication.TCP
{
    public class TcpMessageNotifier : IMessageNotifier
    {
        public event MessageNotificationEvent OnMessageRecieved;
        private readonly TcpListener mListener;

        public TcpMessageNotifier()
        {
            mListener = new TcpListener(IPAddress.Any, 8001);
        }

        public void Start()
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
                    OnMessageRecieved(message, new TcpMessageResponseSender(socket));
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
