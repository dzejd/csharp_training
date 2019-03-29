using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAdressbookTests
{
    [TestFixture]

    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("fykfky");
            group.Header = "ggg";
            group.Footer = "djtdtjdj";
            app.Groups.Create(group);
        }

        [Test]
        public void GroupCreationTest2()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
        }
    }
}

