using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class NewContactData : TestBase
    {
        private string firstname;
        private string lastname;


        public NewContactData(string firstname)
        {
            this.firstname = firstname;
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
    }
}
