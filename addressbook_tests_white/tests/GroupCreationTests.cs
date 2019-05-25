using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGrops = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            { Name = "white" };

            app.Groups.Add(newGroup);

            List<GroupData> newGrops = app.Groups.GetGroupList();
            oldGrops.Add(newGroup);
            oldGrops.Sort();
            newGrops.Sort();

            Assert.AreEquel(oldGrops, newGroups);
        }
    }
}
