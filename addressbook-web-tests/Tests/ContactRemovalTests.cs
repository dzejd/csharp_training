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

    public class ContactRemovalTest : ContactTestBase
    {
        [Test]

        public void ContactRemovalTests()
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            if (!app.Contacts.IsContactPresent())
            {
                ContactData member = new ContactData("SodanieDlya", "Udaleniya");
                app.Contacts.CreateMember(member);
                oldContacts = app.Contacts.GetContactsList();
            }
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in oldContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }





        }

    }
}



