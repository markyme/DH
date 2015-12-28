using System;
using System.Collections.Generic;
using DigitalHouse.BL.Commands;
using DigitalHouse.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB;
using DigitalHouse.DB.UsersRepo;
using FakeItEasy;
using FakeItEasy.Creation;
using FakeItEasy.ExtensionSyntax.Full;
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
            var fakeUsersReporisotyr = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();

            var commandParser = new DigitalHouse.BL.CommandParsers.CommandParser(fakeDeviceRepository, fakeUsersReporisotyr, fakeLogin);
            var command = commandParser.Parse(inputCommand);

            Assert.AreEqual(expectedParsing, command.GetType());
        }
    }
}
