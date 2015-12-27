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
            IDeviceRepository fakeDeviceRepository = A.Fake<IDeviceRepository>();
            var deviceRepoContent = new ConcurrentDictionary<string, SettableDevice>();
            deviceRepoContent.TryAdd("light", new SettableDevice("light", 100));
            deviceRepoContent.TryAdd("light2", new SettableDevice("light", 100));
            A.CallTo(() => fakeDeviceRepository.GetDevices()).Returns(deviceRepoContent);

            ListDevices listDevices = new ListDevices(fakeDeviceRepository);

            var response = listDevices.Execute();
            Debug.WriteLine(response);
        }

        [Test]
        public void A2()
        {

        }

        [Test]
        public void A3()
        {

        }

        [Test]
        public void A4()
        {

        }


    }
}