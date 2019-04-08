using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            group.Header = null;
            group.Footer = null;
            app.Groups.Create(group);
        }

        [Test]
        public void GroupCreationTest2()
        {

            GroupData group = new GroupData("111111111");
            group.Header = null;
            group.Footer = null;
            app.Groups.Create(group);
        }
    }
}

