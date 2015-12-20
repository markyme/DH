using System;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using FakeItEasy;
using FakeItEasy.Creation;
using NUnit.Framework;

namespace DigitalHouseTests.CommandParser
{
    [TestFixture] 
    public class CommandParserTests
    {
        private const string SomeInvalidCommand = "SomethingInvalid";
        private const string AllUppercaseCommand = "LISTDEVICES";
        private const string NotEnoughParametersWithCommand = "SetDeviceValue device";
        private const string TooMuchParametersWithCommand = "SetDeviceValue device value something";

        private static readonly object[] InputOutputCases =
        {
            new object[] { SomeInvalidCommand, typeof(UnknownCommand) },
            new object[] { AllUppercaseCommand, typeof(ListDevices) },
            new object[] { "", typeof(UnknownCommand) },
            new object[] { null, typeof(UnknownCommand) },
            new object[] { NotEnoughParametersWithCommand, typeof(SetDeviceValue) },
            new object[] { TooMuchParametersWithCommand, typeof(SetDeviceValue) },
            new object[] { "ListDevices", typeof(ListDevices) },
            new object[] { "SetDeviceValue", typeof(SetDeviceValue) }
            
        };

        [Test, TestCaseSource("InputOutputCases")]
        public void InputOutputTest(string inputCommand, Type expectedParsing)
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var fakeHomeSession = A.Fake<IHomeSession>();

            fakeHomeSession.Login();
            var commandParser = new DigitalHouse.BL.CommandParsers.CommandParser(fakeDeviceRepository);
            var command = commandParser.Parse(inputCommand);
            Assert.AreEqual(expectedParsing, command.GetType());
        }
    }


    [TestFixture]
    public class UnknownCommandTests
    {
        [Test]
        public void UnknownCommand_CanExecute_True()
        {
            UnknownCommand unknownCommand = A.Fake<UnknownCommand>();
            Assert.AreEqual(true, unknownCommand.CanExecute());
        }

        [Test]
        public void UnknownCommand_Execute_CorrectResponse()
        {
            UnknownCommand unknownCommand = A.Fake<UnknownCommand>();
            const string UnknownCommandExpectedExecuteString = "UnknownCommand.";
            Assert.AreEqual(UnknownCommandExpectedExecuteString, unknownCommand.Execute());
        }
    }


    [TestFixture]
    public class ListDevicesTests
    {
        
    }
}
