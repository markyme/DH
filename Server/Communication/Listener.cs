using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DigitalHouse.Communication;

namespace Server.Communication
{
    public class Listener
    {
        public CommunicationProtocalEvent requestedCommand;

        private TcpListener listner;
        private Socket socket;
        public Listener()
        {
            IPAddress ipAd = IPAddress.Parse("192.168.0.62");
            listner = new TcpListener(ipAd, 8001);
        }

        public void StartListener()
        {
            listner.Start();
            Console.WriteLine("Waiting for a connection.....");
            HandleRequests();
        }

        private void HandleRequests()
        {
            socket = listner.AcceptSocket();
            Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);

            while (socket.Connected)
            {
                byte[] receivingBuffer = new byte[100];
                int k = socket.Receive(receivingBuffer);

                String message = "";
                for (var i = 0; i < k; i++)
                {
                    message += Convert.ToChar(receivingBuffer[i]);
                }
                if (message.Equals("\r\n"))
                {
                    continue;
                }

                Console.WriteLine("Recieved: " + message);
                requestedCommand(this, new MessageParameters { message = message });
            }
        }

        public void sendMessageToClient(string message)
        {
            socket.Send(Encoding.ASCII.GetBytes(message));
        }
    }
}
