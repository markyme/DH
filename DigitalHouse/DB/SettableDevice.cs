using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public class SettableDevice
    {
        public string name;
        public int value;

        public SettableDevice(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
