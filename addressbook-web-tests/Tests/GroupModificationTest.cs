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

    public class GroupModificationTest : TestBase
    {
        [Test]

        public void GroupModificationTests()
        {
            
            GroupData newData = new GroupData("fykfky");
            newData.Header = "yhgg";
            newData.Footer = "djtdtjdj";

            app.Groups.Modify(1, newData);
        }
    }
}
