﻿using System;
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
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();
            NewContactData member = new NewContactData("IvanovIvanIvanovich");
            member.FirstName = "Gideon";
            member.LastName = "Reyvenor";
            app.Contacts.InitContactCreation(member);
            app.Contacts.SubmitAdd();
            app.Contacts.BackHomePage();
            app.Contacts.LogoutFromContactCreation();
        }
    }
}