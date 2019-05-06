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
    }
}

