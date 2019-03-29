using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAdressbookTests
{
    public class TestBase
    {
        protected ApplicationMeneger app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationMeneger();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
