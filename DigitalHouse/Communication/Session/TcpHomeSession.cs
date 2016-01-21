using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalHouse.BL.CommandExecutors;
using DigitalHouse.BL.CommandParsers;
using DigitalHouse.Communication.Protocols;
using DigitalHouse.Communication.TCP;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;

namespace DigitalHouse.Communication.Session
{
    public class TcpHomeSession : IHomeSession
    {
        private readonly IObservable<string> OnMessageRecievedObservable; 
        private readonly Socket mSocket;

        private bool mIsLoggedIn;
        public  bool IsLoggedIn() { return mIsLoggedIn; }
        public  void Login() { mIsLoggedIn = true; }

        public TcpHomeSession(Socket socket)
        {
            mSocket = socket;

            OnMessageRecievedObservable = Observable.Create(
               (IObserver<string> observer) =>
               {
                   while (mSocket.Connected)
                   {
                       try
                       {
                           var message = GetMessageFromClient(mSocket);
                           if (message.Equals("\r\n")) { continue; }
                           Console.WriteLine("Recieved: " + message);

                           observer.OnNext(message);
                       }
                       catch (Exception exception)
                       {
                           Console.WriteLine(exception);
                           mSocket.Close();
                           observer.OnError(exception);
                       }
                   }
                   observer.OnCompleted();
                   return Disposable.Empty;
               });
        }

        public IObservable<string> getOnMessageRecievedObservable()
        {
            return OnMessageRecievedObservable;
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
