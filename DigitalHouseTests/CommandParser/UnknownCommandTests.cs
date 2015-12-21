using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.Commands;
using FakeItEasy;
using NUnit.Framework;

namespace DigitalHouseTests.CommandParser
{
    [TestFixture]
    public class UnknownCommandTests
    {
        [Test]
        public void UnknownCommand_CanExecute_True()
        {
            UnknownCommand unknownCommand = A.Fake<UnknownCommand>();

            bool result = unknownCommand.CanExecute();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void UnknownCommand_Execute_CorrectResponse()
        {
            UnknownCommand unknownCommand = A.Fake<UnknownCommand>();
            const string UnknownCommandExpectedExecuteString = "UnknownCommand.";

            bool result = unknownCommand.CanExecute();

            Assert.AreEqual(UnknownCommandExpectedExecuteString, result);
        }
    }

}
