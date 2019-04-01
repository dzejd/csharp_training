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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
         : base(manager)
        {
        }

        public ContactHelper CreateMember(NewContactData member)
        {
            manager.Navigator.GoToGroupPage();
            AddNewContact();
            InitContactCreation(member);
            SubmitAdd();
            BackHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveCont();
            BackHome();
            return this;
        }

        public ContactHelper Modify(int v, NewContactData newContact)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
            InitContactCreation(newContact);
            UpdateContactInfo();
            BackHomePage();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper MainTableSelection(int numb)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + numb + "]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveCont()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactCreation(NewContactData newContact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(newContact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(newContact.LastName);
            return this;
        }

        public ContactHelper SubmitAdd()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper BackHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper BackHome()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])")).Click();
            return this;
        }

        public ContactHelper UpdateContactInfo()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

    }


}
