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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> member = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                member.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    FirstName = GenerateRandomString(100),
                    LastName = GenerateRandomString(100)
                });
            }
            return member;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData member)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.CreateMember(member);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(member);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
