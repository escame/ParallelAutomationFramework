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
using AutomationFrameWork.Exceptions;

namespace AutomationTesting
{
    [Category("TestEvent")]
    public class UnitTest1
    {
        [Test]
        public void TestListner1()
        {
            Assert.True(true);
            Thread.Sleep(7000);
        }
        [Test]
        public void TestListner2()
        {
            Assert.True(true);
            Thread.Sleep(7000);
        }
        [Test]
        public void TestListner3()
        {
            Assert.True(true);
            Thread.Sleep(7000);
        }
        [Test]
        public void TestListner4()
        {
            Assert.True(true);
            Thread.Sleep(7000);
        }
        [Test]
        public void TestListner5()
        {
            Assert.True(true);
            Thread.Sleep(7000);
        }
    }    
}