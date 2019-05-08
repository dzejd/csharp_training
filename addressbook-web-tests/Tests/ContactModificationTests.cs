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
            NewContactData newMember = new NewContactData("verter");
            newMember.FirstName = null;
            newMember.LastName = "aqwe";

            if (!app.Contacts.IsContactExist())
            {
                NewContactData contact = new NewContactData("qqq", "www");
                app.Contacts.CreateMember(contact);
            }
            app.Contacts.Modify(newMember);
        }



        /* [Test]

         public void ContactModificationTest()
         {
             NewContactData newMember = new NewContactData("verter");
             newMember.FirstName = null;
             newMember.LastName = "aqwe";

             app.Contacts.Modify(newMember); */
    }
}
