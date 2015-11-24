using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.Communication
{
    public delegate void CommunicationProtocalEvent(TCPListener sender, MessageParameters messageParameters);
}
public class MessageParameters : EventArgs
{
    public string message { get; set; }
}