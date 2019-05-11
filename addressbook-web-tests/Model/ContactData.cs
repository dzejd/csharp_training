using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;


        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.FirstName);
            }
            return FirstName.CompareTo(other.LastName);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public int GetHashCodeFirstName()
        {
            return FirstName.GetHashCode();
        }

        public int GetHashCodeLastName()
        {
            return LastName.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + LastName;
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
