using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;

namespace DigitalHouse.Commands
{
    public interface Command
    {
        string GetName();
        string ExecuteCommand(HardCodedDataBase dataBase);
    }
}
