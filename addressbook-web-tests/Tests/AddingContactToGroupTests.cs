using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbookTests;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]

    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
            {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}