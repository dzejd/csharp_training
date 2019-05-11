using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        public ContactHelper CreateMember(ContactData member)
        {
            managerApp.Navigator.GoToHomePage();
            AddNewContact();
            InitContactCreation(member);
            SubmitAdd();
            managerApp.Navigator.BackHomePage();
            return this;
        }

        public ContactHelper Remove()
        {
            managerApp.Navigator.GoToHomePage();
            SelectContact();
            RemoveCont();
            BackHome();
            return this;
        }

        public ContactHelper Modify(ContactData newContact)
        {
            managerApp.Navigator.GoToHomePage();
            SelectContact();
            InitContactModification();
            InitContactCreation(newContact);
            UpdateContactInfo();
            managerApp.Navigator.BackHomePage();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        private List<ContactData> contCash = null;

        public List<ContactData> GetContactsList()
        {
            if (contCash == null)
            {
                contCash = new List<ContactData>();
                List<ContactData> contact = new List<ContactData>();
                managerApp.Navigator.GoToHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> someValue = element.FindElements(By.TagName("td"));
                    contCash.Add(new ContactData(someValue[2].Text, someValue[1].Text)
                    { Id = element.FindElement(By.TagName("center")).GetAttribute("value") });
                    contCash.Add(new ContactData(someValue[2].Text, someValue[1].Text));
                }
            }
            return new List<ContactData>(contCash);
        }

        public ContactHelper SearchCountOnPage()
        {
            driver.FindElement(By.XPath("//span[@name='search_count'])[0]"));
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
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
            contCash = null;
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactCreation(ContactData newContact)
        {
            Type(By.Name("firstname"), newContact.FirstName);
            Type(By.Name("lastname"), newContact.LastName);
            return this;
        }

        public ContactHelper SubmitAdd()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contCash = null;
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
            contCash = null;
            return this;
        }

        public ContactHelper UpdateContactInfo()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.XPath("(//img[@alt='Edit'])[" + (1) + "]"));
        }
    }
}
