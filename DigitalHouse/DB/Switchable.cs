using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHouse.DB
{
    public class Switchable
    {
        public string name;
        public bool state;

        public Switchable(string name, bool state)
        {
            this.name = name;
            this.state = state;
        }
    }
}
