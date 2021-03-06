﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Communication;

namespace DigitalHouse.Communication
{
    public delegate void CommunicationProtocalEvent(Listener sender, MessageParameters messageParameters);
}
public class MessageParameters : EventArgs
{
    public string message { get; set; }
}