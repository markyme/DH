using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.BL.Commands;
using DigitalHouse.Communication.Session;
using DigitalHouse.DB.UsersRepo;
using FakeItEasy;
using NUnit.Framework;

namespace DigitalHouseTests.CommandParser
{
    [TestFixture]
    public class LoginTests
    {
        [Test]
        public void Login_UserExist_CommandPassed()
        {
            const string EXISTING_USER = "UserNameWithoutWhiteSpaces";
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();
            A.CallTo(() => fakeUserRepository.IsExists(EXISTING_USER)).Returns(true);
            List<string> parameters = new List<string> { EXISTING_USER };

            var login = new Login(fakeUserRepository, fakeLogin, parameters);

            Assert.AreEqual(true, login.CanExecute());
            Assert.AreEqual("OK", login.Execute());
        }

        [Test]
        public void Login_UserDoesntExist_CannotExecute()
        {
            const string NON_EXISTING_USER = "UserNameWithoutWhiteSpaces";
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();
            A.CallTo(() => fakeUserRepository.IsExists(NON_EXISTING_USER)).Returns(false);
            List<string> parameters = new List<string> { NON_EXISTING_USER };

            var login = new Login(fakeUserRepository, fakeLogin, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }

        [Test]
        public void Login_EmptyStringAsParameter_CannotExecute()
        {
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();
            List<string> parameters = new List<string> { "" };

            var login = new Login(fakeUserRepository, fakeLogin, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }

        [Test]
        public void Login_NullAsParameter_CannotExecute()
        {
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();
            List<string> parameters = new List<string> { null };

            var login = new Login(fakeUserRepository, fakeLogin, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }

        [Test]
        public void Login_TooMuchParameters_CannotExecute()
        {
            const string SOME_PARAMETER_VALUE = "NonSegnificantValue";

            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();
            List<string> parameters = new List<string> { SOME_PARAMETER_VALUE, SOME_PARAMETER_VALUE };

            var login = new Login(fakeUserRepository, fakeLogin, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }

        [Test]
        public void Login_NoParameters_CannotExecute()
        {
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            var fakeLogin = A.Fake<ILoginActions>();
            List<string> parameters = new List<string> {};

            var login = new Login(fakeUserRepository, fakeLogin, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }
    }
}

/*        const string EXISTING_USER = "userexists";
        const string NON_EXISTING_USER = "doesntexist";

        private static readonly object[] UserInputAndOutputCases =
        {
            new object[] { EXISTING_USER, true, "true"},
            new object[] { NON_EXISTING_USER, true, "false"},

        };

        [Test, TestCaseSource("UserInputAndOutputCases")]
        public void ParameterInputAndResponses(string parameters, bool canExecute, string executeResponse)
        {
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            A.CallTo(() => fakeUserRepository.IsExists(parameters)).Returns(true);
        }*/

// 
