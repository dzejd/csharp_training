using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void MenuProjects()
        {
            OpenManagePage();
            GoToProjectsPage();
        }

        public void OpenManagePage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.4.1/manage_overview_page.php";
        }

        public void GoToProjectsPage()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}
