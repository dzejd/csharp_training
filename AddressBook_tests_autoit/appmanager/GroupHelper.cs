using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoItX3Lib;

namespace AddressBook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControltreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.62e4491", "GetItemCount", "#0");
            for (int i = 0; i < int.Parse(count); i++)
            {
               string item = aux.ControltreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.62e4491", "GetText", "#0|#"+i);
                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupsDialogue();
            return list;
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.62e44912");
            aux.WinWait(GROUPWINTITLE);
        }

        public void Add(GroupData newGroup)
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.62e44912");
            aux.WinWait(GROUPWINTITLE);
            aux.ControClic(GROUPWINTITLE, "WindowsForms10.BUTTON.app.0.62e4493");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControClic(GROUPWINTITLE, "WindowsForms10.BUTTON.app.0.62e4494");
        }
    }
}