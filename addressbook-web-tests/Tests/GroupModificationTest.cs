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

    public class GroupModificationTest : AuthTestBase
    {
        [Test]

        public void GroupModificationTests()
        {
            GroupData newData = new GroupData("Group_Name_1");
            newData.Header = null;
            newData.Footer = null;

            if (!app.Groups.IsGroupExist())
            {
                GroupData group = new GroupData("Group_Name_");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            app.Groups.Modify(1, newData);
        }

        [Test]

        public void GroupModificationTests2()
        {

            GroupData newData = new GroupData("fykfky");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

    }
}
