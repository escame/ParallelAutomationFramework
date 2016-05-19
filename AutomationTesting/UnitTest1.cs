using System;
using NUnit.Framework;
using AutomationFrameWork.Reporter.ReportAttributes;
using AutomationFrameWork.Driver;
using AutomationFrameWork.Driver.Core;
using AutomationFrameWork.Utils;
using AutomationFrameWork.Reporter.ReportItems;
using System.Data;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Collections;
using AutomationFrameWork.Helper;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.ActionsKeys;

namespace AutomationTesting
{ 
    
    public class UnitTest1 
    {
        [Test]   
        [TestCaseSource(typeof(DataHelper), "DataDrivenExcel", new object[] { "C:\\Users\\minhhoang\\Desktop\\Selenium Semninar\\BigData.xlsx", "Test1", false })]
        public void TestMapping(string a,string b,string c,string d)
        {            
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);           
            Console.WriteLine("============================");                      
        }
        [Test]
        public void TestKey ()
        {
            DriverFactory.Instance.StartDriver(DriverType.Chrome);
            WebKeywords.Instance.OpenUrl("www.google.com");
        }    
    }
}
