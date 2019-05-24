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

    public class GroupModificationTest : GroupTestBase
    {
        [Test]

        public void GroupModificationTests()
        {

            GroupData newData = new GroupData("fykfky");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll();
            if (!app.Groups.IsGroupExist())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "sss";
                group.Footer = "ddd";
                app.Groups.Create(group);
                oldGroups = app.Groups.GetGroupList();
            }
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
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
