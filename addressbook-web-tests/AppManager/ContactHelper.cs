﻿using System;
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

                public ContactHelper Remove(ContactData contact)
        {
            managerApp.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            RemoveCont();
            BackHome();
            return this;
        }

        public ContactHelper Modify(ContactData oldData, ContactData newContact)
        {
            managerApp.Navigator.GoToHomePage();
            SelectContact();
            InitContactModification(oldData.Id);
            InitContactCreation(newContact);
            UpdateContactInfo();
            managerApp.Navigator.BackHomePage();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            managerApp.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void DeleteContactFromGroup(ContactData contact, string groupId)
        {
            managerApp.Navigator.GoToHomePage();
            GoToPageContactDataView(contact.Id);
            GoToGroupPage(groupId);
            SelectContact(contact.Id);
            InitRemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void InitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void GoToGroupPage(string groupId)
        {
            driver.FindElement(By.XPath("//a[@href='./index.php?group=" + groupId + "']")).Click();
        }

        private void GoToPageContactDataView(string id)
        {
            driver.FindElement(By.XPath("//a[@href='view.php?id=" + id + "']")).Click();
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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
                    ContactData listContacts = new ContactData(someValue[2].Text, someValue[1].Text);
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement element = driver.FindElement(By.CssSelector("div.msgbox"));
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

        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
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

        public ContactData GetContactInformationFromTable(int index)
        {
            managerApp.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            managerApp.Navigator.GoToHomePage();
            OpenContactInformationFromViewForm(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetContactInformationForView()
        {
            managerApp.Navigator.GoToHomePage();
            OpenContactInformationFromViewForm(1);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string contactInformation = (firstName + " ") + (lastName + " ") + address + homePhone + mobilePhone + workPhone + email + email2 + email3;

            return CleanUpText(contactInformation).Trim();
        }

        public string GetContactInformationFromViewForm(int index)
        {
            managerApp.Navigator.GoToHomePage();
            OpenContactInformationFromDetailForm(index);
            string allText = driver.FindElement(By.Id("content")).Text;
            return CleanUpText(allText).Trim();
        }

        public string CleanUpText(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return Regex.Replace(text, "[ -()]H:M:W:\r\n", "");
        }

        public ContactHelper OpenContactInformationFromViewForm(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper OpenContactInformationFromDetailForm(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            managerApp.Navigator.GoToHomePage();
            string iText = driver.FindElement(By.TagName("lable")).Text;
            Match m = new Regex(@"\d+").Match(iText);
            return Int32.Parse(m.Value);
        }

        public bool IsContactPresent()
        {
            managerApp.Navigator.GoToHomePage();
            return IsElementPresent(By.XPath("(//img[@alt='Edit'])[" + (1) + "]"));
        }

    }
}
