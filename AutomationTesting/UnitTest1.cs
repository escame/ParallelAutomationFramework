using System;
using NUnit.Framework;
using AutomationFrameWork.Reporter.ReportAttributes;
using AutomationFrameWork.Driver;
using AutomationFrameWork.Driver.Core;
using AutomationFrameWork.Utils;
using AutomationFrameWork.Reporter.ReportItems;
using System.Data;
namespace AutomationTesting
{ 
    [TestFixture]
    public class UnitTest1 
    {
        [Test]
        public void TestMapping ()
        {
            //DriverFactory.Instance.StartDriver(DriverType.Chrome);
            //DriverFactory.Instance.GetWebDriver.Url = "http://www.google.com";
            //DriverFactory.Instance.CloseDriver();        
            /*
            DataTable temp = ExcelUtilities.Instance.GetExcelData("C:\\Users\\minhhoang\\Desktop\\Selenium Semninar\\BigData.xlsx", "Test",false);
            int row=temp.Rows.Count;
            int col = temp.Columns.Count;
            Console.WriteLine("Max row in excel: " + row);
            Console.WriteLine("Max col in excel: " + col);
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Current Row: "+(i+1));
                for (int j = 0; j < col; j++)
                    Console.WriteLine(temp.Rows[i][j].ToString());
            }
            */
            
            DataTable temp = ExcelUtilities.Instance.GetExcelData("C:\\Users\\minhhoang\\Desktop\\Selenium Semninar\\BigData.xlsx", "Test", true);
            int row = temp.Rows.Count;
            int col = temp.Columns.Count;
            Console.WriteLine("Max row in excel: " + row);
            Console.WriteLine("Max col in excel: " + col);
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("============================Test");
                Console.WriteLine("Current Row: " + (i + 1));
                for (int j = 0; j < col; j++)
                    Console.WriteLine(temp.Rows[i][j].ToString());
            }

        }
    }
}
