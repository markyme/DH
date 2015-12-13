using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.Session;

namespace DigitalHouse.Communication.TCP
{
    public class TcpNewSessionNotifier : INewSessionNotifier
    {
        private readonly TcpListener mListener;
        public event NewSessionEvent OnNewSession;

        public TcpNewSessionNotifier()
        {
            mListener = new TcpListener(IPAddress.Any, 8001);
        }

        public void Start()
        {
            mListener.Start();
            Console.WriteLine("Waiting for a connection.....");
            while (true)
            {
                if (!mListener.Pending()) continue;

                var socket = mListener.AcceptSocket();
                new Thread(() => CreateNewSession(socket)).Start();
            }
        }


        public void CreateNewSession(Socket socket)
        {
            Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);
            var session = new TcpHomeSession(socket);
            OnNewSession(session);
            session.Listen();
        }
    }
}
