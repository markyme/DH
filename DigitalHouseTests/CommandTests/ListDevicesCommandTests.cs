using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.BL.Commands;
using DigitalHouse.DB;
using FakeItEasy;
using NUnit.Framework;

namespace DigitalHouseTests.CommandTests
{
    [TestFixture]
    internal class ListDevicesCommandTests
    {
        [Test]
        public void ListDevice_NoDevicesOnDB_NoDevicesFound()
        {
            IDeviceRepository fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var listDevices = new ListDevices(fakeDeviceRepository);

            var response = listDevices.Execute();

            Assert.AreEqual("No Devices Found", response);
        }

        [Test]
        public void ListDevices_TwoDevicesOnDB_BothDevicesShown()
        {
            const string someDeviceName = "light";
            const string otherDeviceName = "light2";
            const int someIntDeviceState = 100;

            var expectedResponse =
                someDeviceName + ", State: " +
                someIntDeviceState +
                Environment.NewLine +
                otherDeviceName + ", State: " +
                someIntDeviceState;

            IDeviceRepository fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var deviceRepo = new ConcurrentDictionary<string, SettableDevice>();
            deviceRepo.TryAdd(someDeviceName, new SettableDevice(someDeviceName, someIntDeviceState));
            deviceRepo.TryAdd(otherDeviceName, new SettableDevice(otherDeviceName, someIntDeviceState));
            A.CallTo(() => fakeDeviceRepository.GetDevices()).Returns(deviceRepo);

            ListDevices listDevices = new ListDevices(fakeDeviceRepository);

            var response = listDevices.Execute();
            Assert.AreEqual(expectedResponse, response);
        }
    }
}