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
            if (!app.Contacts.IsContactExist())
            {
                ContactData member = new ContactData("SodanieDlya", "Udaleniya");
                member.FirstName = "SodanieDlya1";
                member.LastName = "Udaleniya1";
                app.Contacts.CreateMember(member);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Remove();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);





        }

    }
}



