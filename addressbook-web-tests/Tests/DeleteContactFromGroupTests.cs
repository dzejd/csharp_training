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
    public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
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

            if (!app.Contacts.IsContactPresent())
            {
                contact = new ContactData("qqq", "www");
                app.Contacts.CreateMember(contact);
            }

            group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            contact = ContactData.GetAll().First();
            if (oldList.Count == 0)
            {
                app.Contacts.AddContactToGroup(contact, group);
                oldList = group.GetContacts();
            }
            else
            {
                contact = group.GetContacts().First();
            }

            app.Contacts.DeleteContactFromGroup(contact, group.Id);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
