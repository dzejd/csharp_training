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
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            NewContactData member = new NewContactData("IvanovIvanIvanovich");
            member.FirstName = null;
            member.LastName = null;

            List<NewContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.CreateMember(member);

            List<NewContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(member);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
