using DigitalHouse.Communication.TCP;

namespace DigitalHouse.Communication.Protocols
{
    public delegate void MessageNotificationEvent(string request, IMessageResponseSender responseSender);
}

