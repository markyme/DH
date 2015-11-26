using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.DB;

namespace DigitalHouse.Commands
{
    public interface ICommand
    {
        string GetName();
        string ExecuteCommand();
    }
}
