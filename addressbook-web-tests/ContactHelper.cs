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
        private IWebDriver driver;

        public ContactHelper(IWebDriver driver)
            : base(driver)
        {
        }

        public void AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void InitContactCreation(NewContactData member)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(member.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(member.LastName);
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        public void LogoutFromContactCreation()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void BackHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void SubmitAdd()
        {
            driver.FindElement(By.Name("theform")).Click();
        }


    }
}
