using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalHouse.BL.Commands;
using DigitalHouse.DB.UsersRepo;
using FakeItEasy;
using NUnit.Framework;

namespace DigitalHouseTests.CommandParser
{
    [TestFixture]
    public class LoginTests
    {
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


        [Test]
        public void Login_UserExist_CommandPassed()
        {
            const string EXISTING_USER = "UserNameWithNoWhitespace";
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            A.CallTo(() => fakeUserRepository.IsExists(EXISTING_USER)).Returns(true);
            List<string> parameters = new List<string> { EXISTING_USER };

            var login = new Login(fakeUserRepository, parameters);

            Assert.AreEqual(true, login.CanExecute());
            Assert.AreEqual("true", login.Execute());
        }

        [Test]
        public void Login_UserDoesntExist_CommandPassed()
        {
            const string NON_EXISTING_USER = "doesntexist";
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            A.CallTo(() => fakeUserRepository.IsExists(NON_EXISTING_USER)).Returns(false);
            List<string> parameters = new List<string> { NON_EXISTING_USER };

            var login = new Login(fakeUserRepository, parameters);

            Assert.AreEqual(true, login.CanExecute());
            Assert.AreEqual("false", login.Execute());
        }

        [Test]
        public void Login_EmptyStringAsParameter_CannotExecute()
        {
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            List<string> parameters = new List<string> { "" };

            var login = new Login(fakeUserRepository, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }

        [Test]
        public void Login_NullAsParameter_CannotExecute()
        {
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();
            List<string> parameters = new List<string> { null };

            var login = new Login(fakeUserRepository, parameters);

            Assert.AreEqual(false, login.CanExecute());
        }
    }
}
