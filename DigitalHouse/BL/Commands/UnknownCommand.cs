﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;

namespace DigitalHouse.Commands
{
    public class UnknownCommand : ICommand
    {
        public string GetName()
        {
            return "UnknownCommand";
        }

        public string Execute()
        {
            return "UnknownCommand.";
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
