using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public class SettableDevice
    {
        public string Name;
        public int Value;

        public SettableDevice(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
