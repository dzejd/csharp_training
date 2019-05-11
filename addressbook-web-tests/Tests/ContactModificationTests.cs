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

    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData newMember = new ContactData("Exersize", "9");
            newMember.FirstName = "Modifikaciya";
            newMember.LastName = "Kontacta";

            if (!app.Contacts.IsContactExist())
            {
                ContactData contact = new ContactData("Exersize", "9-1");
                app.Contacts.CreateMember(contact);
            }
            app.Contacts.Modify(newMember);
        }



        [Test]

        public void ContactModificationTest2()
        {
            ContactData newContacts = new ContactData("Exersize", "9-2");
            newContacts.FirstName = "ZamenaImeni";
            newContacts.LastName = "ZamenaFamilii";

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Modify(newContacts);

            List<ContactData> newListContats = app.Contacts.GetContactsList();

            oldContacts[0].FirstName = newContacts.FirstName;
            oldContacts[0].LastName = newContacts.LastName;

            oldContacts.Sort();
            newListContats.Sort();

            Assert.AreEqual(oldContacts, newListContats);
        }
    }
}
