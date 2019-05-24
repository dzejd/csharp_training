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

    public class ContactModificationTests : ContactTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Exersize", "9-2");
            List<ContactData> oldContacts = ContactData.GetAll();
            if (!app.Contacts.IsContactPresent())
            {
                ContactData contact = new ContactData("qqq", "www");
                app.Contacts.CreateMember(contact);
                oldContacts = app.Contacts.GetContactsList();
            }
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }
    }
}
