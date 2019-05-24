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
    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = new GroupData();
            ContactData contact = new ContactData();

            if (!app.Groups.IsGroupExist())
            {
                group = new GroupData("aaa");
                group.Header = "sss";
                group.Footer = "ddd";
                app.Groups.Create(group);
            }

            group = GroupData.GetAll()[0];

            if (!app.Contacts.IsContactPresent() || group.GetContactsNotInGroups().Count == 0)
            {
                contact = new ContactData("qqq", "www");
                app.Contacts.CreateMember(contact);
            }

            List<ContactData> oldList = group.GetContacts();

            contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
