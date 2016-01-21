using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Communication.Protocols;

namespace DigitalHouse.Communication.Session
{
    public interface IHomeSession : ILoginActions
    {
        IObservable<string> getOnMessageRecievedObservable();

        void Write(string message);
     
    }

    public interface ILoginActions
    {
        bool IsLoggedIn();
        void Login();
    }
}
