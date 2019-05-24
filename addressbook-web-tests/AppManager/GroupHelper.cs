using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
    : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            managerApp.Navigator.GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnHomePage();
            return this;
        }

        public GroupHelper Modify(GroupData oldData, GroupData newData)
        {
            managerApp.Navigator.GoToGroupPage();
            SelectGroup(oldData.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnHomePage();

            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            managerApp.Navigator.GoToGroupPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnHomePage();
            return this;
        }

        private List<GroupData> groupCash = null;

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                managerApp.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCash.Add(new GroupData(null)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCash.Count - parts.Length;
                for (int i = 0; i < groupCash.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCash[i].Name = "";
                    }
                    else
                    {
                        groupCash[i].Name = parts[i - shift].Trim();
                    }
                    groupCash[i].Name = parts[i].Trim();
                }
            }
            return new List<GroupData>(groupCash);
        }

        public GroupHelper ReturnHomePage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper ReturnGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool IsGroupExist()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (1) + "]"));
        }
    }
}
