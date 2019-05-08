using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]

    public class ContactRemovalTest : AuthTestBase
    {
        [Test]

        public void ContactRemovalTests()
        {
            app.Contacts.Remove();
        }
    }
}
