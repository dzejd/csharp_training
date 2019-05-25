using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGrops = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            { Name = "test" };


            app.Groups.Add(newGroup);

            List<GroupData> newGrops = app.Groups.GetGroupList();
            oldGrops.Add(newGroup);
            oldGrops.Sort();
            newGrops.Sort();

            Assert.AreEquel(oldGrops, newGroups);
        }
    }
}
