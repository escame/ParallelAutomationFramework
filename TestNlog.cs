using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NLog;
using AutomationFrameWork.Base;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net.Sockets;
using AutomationFrameWork.Driver.Core;
using AutomationFrameWork.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Reporter.ReportAttributes;

namespace AutomationFrameWork.Log
{   [HTML]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]    
    public class NLOG 
    {
        [Test]
        public void TestReport1 ()
        {
            Assert.IsTrue(false);
        }
        [Test]
        public void TestReport2 ()
        {
            Assert.IsTrue(true);
        }
    }

}
