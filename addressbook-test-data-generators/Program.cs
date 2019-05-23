using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbookTests;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[1];
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];
            string dataType = args[0];
            int count = Convert.ToInt32(args[0]);

            if (dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer1 = new StreamWriter(filename);
                    if (format == "xml")
                    {
                        WriteGroupsToXMLFile(groups, writer1);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer1);
                    }
                    else
                    {
                        Console.Out.Write("Bad format" + format);
                    }
                    writer1.Close();
                }
            }
            else if (dataType == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                }
                StreamWriter writer2 = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer2);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer2);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer2);
                }
                else
                {
                    Console.Out.Write("Unrecognized format" + format);
                }
                writer2.Close();
            }
            else
            {
                Console.Out.Write("Bad data - " + dataType);
            }
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.FirstName, contact.LastName));
            }
        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
