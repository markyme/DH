using DigitalHouse.Communication.Session;
using DigitalHouse.Communication.TCP;

namespace DigitalHouse.Communication.Protocols
{
    public delegate void NewMessageRecievedEvent(IHomeSession homeSession, string request);
}

