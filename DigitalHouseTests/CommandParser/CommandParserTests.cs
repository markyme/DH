using System;
using System.Runtime.InteropServices;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using FakeItEasy;
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

        private static object[] InputOutputCases =
        {
            new object[] { SomeInvalidCommand, typeof(UnknownCommand) },
            new object[] { AllUppercaseCommand, typeof(ListDevices) },
            new object[] { "", typeof(UnknownCommand) },
            new object[] { null, typeof(UnknownCommand) },
            new object[] { NotEnoughParametersWithCommand, typeof(SetDeviceValue) },
            new object[] { TooMuchParametersWithCommand, typeof(SetDeviceValue) }
        };

        [Test, TestCaseSource("InputOutputCases")]
        public void InputOutputTest(string inputCommand, Type expectedParsing)
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var fakeHomeSession = A.Fake<IHomeSession>();

            fakeHomeSession.Login();
            var commandParser = new DigitalHouse.BL.CommandParsers.CommandParser(fakeDeviceRepository, fakeHomeSession);
            var command = commandParser.Parse(inputCommand);
            Assert.AreEqual(expectedParsing, command.GetType());
        }
    }
}
