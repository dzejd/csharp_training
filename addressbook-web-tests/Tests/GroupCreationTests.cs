using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAdressbookTests
{
    [TestFixture]

    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("fykfky");
            group.Header = "awshrdsh";
            group.Footer = "sarg";

         //   List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

         //   List<GroupData> newGroups = app.Groups.GetGroupList();
         //   Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }

        [Test]
        public void GroupCreationTest2()
        {

            GroupData group = new GroupData("111111111");
            group.Header = "asfnh";
            group.Footer = "shjdtk";

         //   List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

          //  List<GroupData> newGroups = app.Groups.GetGroupList();
         //   Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}

