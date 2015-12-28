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
        void Write(string message);
        event NewMessageRecievedEvent OnMessageRecieved;
    }

    public interface ILoginActions
    {
        bool IsLoggedIn();
        void Login();
    }
}
