using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.Communication
{
    public class TCPListener : IListener
    {
        public event CommunicationProtocalEvent OnMessageRecieved;

        private TcpListener listner;
        private Socket socket;
        public TCPListener()
        {
            IPAddress ipAd = IPAddress.Parse("172.16.3.57");
            listner = new TcpListener(ipAd, 8001);
        }

        public void Listen()
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
                try
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
                    OnMessageRecieved(this, new MessageParameters { message = message });
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error with connection: " + exception);
                }
            }
        }

        public void Send(string message)
        {
            socket.Send(Encoding.ASCII.GetBytes(message));
        }
    }
}
