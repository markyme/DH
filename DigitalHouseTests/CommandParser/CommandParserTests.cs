using DigitalHouse.Commands;
using DigitalHouse.DB;
using FakeItEasy;
using NUnit.Framework;

namespace DigitalHouseTests.CommandParser
{
    public class CommandParserTests
    {
        private const string SomeInvalidCommand = "SomethingInvalid";
        private const string UnusualCommandCasing = "LisTDeViCes";
        private const string NotEnoughParametersWithCommand = "SetDeviceValue device";
        private const string TooMuchParametersWithCommand = "SetDeviceValue device value something";

        [Test]
        public void ParseCommand_SomeInvalidCommand_ReturnUnknownCommand()
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var commandParser = new DigitalHouse.CommandParsers.CommandParser(fakeDeviceRepository);

            var command = commandParser.Parse(SomeInvalidCommand);

            Assert.AreEqual(typeof(UnknownCommand), command.GetType());
        }

        [Test]
        public void ParseCommand_UnusualCommandCasing_ReturnCorrectCommand()
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var commandParser = new DigitalHouse.CommandParsers.CommandParser(fakeDeviceRepository);

            var command = commandParser.Parse(UnusualCommandCasing);

            Assert.AreEqual(typeof(ListDevices), command.GetType());
        }

        [Test]
        public void ParseCommand_EmptyCommand_ReturnUnknownCommand()
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var commandParser = new DigitalHouse.CommandParsers.CommandParser(fakeDeviceRepository);

            var command = commandParser.Parse("");

            Assert.AreEqual(typeof(UnknownCommand), command.GetType());
        }

        [Test]
        public void ParseCommand_NullCommand_ReturnUnknownCommand()
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var commandParser = new DigitalHouse.CommandParsers.CommandParser(fakeDeviceRepository);

            var command = commandParser.Parse(null);

            Assert.AreEqual(typeof(UnknownCommand), command.GetType());
        }

        [Test]
        public void ParseCommand_NotEnoughParameters_ReturnUnknownCommand()
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var commandParser = new DigitalHouse.CommandParsers.CommandParser(fakeDeviceRepository);

            var command = commandParser.Parse(NotEnoughParametersWithCommand);

            Assert.AreEqual(typeof(SetDeviceValue), command.GetType());
        }

        [Test]
        public void ParseCommand_TooMuchParameters_ReturnUnknownCommand()
        {
            var fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var commandParser = new DigitalHouse.CommandParsers.CommandParser(fakeDeviceRepository);

            var command = commandParser.Parse(TooMuchParametersWithCommand);

            Assert.AreEqual(typeof(SetDeviceValue), command.GetType());
        }
    }
}
