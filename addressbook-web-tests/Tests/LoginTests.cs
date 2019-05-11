using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace WebAdressbookTests
{
    [TestFixture]

    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            //prerare
            app.Auth.Logout();

            //action
            AccountDate account = new AccountDate("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            //prerare
            app.Auth.Logout();

            //action
            AccountDate account = new AccountDate("admin", "desh");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
