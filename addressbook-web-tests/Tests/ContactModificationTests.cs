using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]

    public class ContactModificationTests : TestBase
    { 
    [Test]
     
    public void ContactModificationTest()
        {
            NewContactData newMember = new NewContactData("verter");
            newMember.FirstName = "Homo";
            newMember.LastName = "Parodic";

            app.Contacts.Modify(1, newMember);
        }
    }
}
