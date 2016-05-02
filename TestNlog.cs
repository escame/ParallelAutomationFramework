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
namespace AutomationFrameWork.Log
{   
    [TestFixture]
    public class NLOG 
    {   
        [Test]
        public void LogFilePass()
        {            
            Assert.IsTrue(true);
        }
        [Test]
        public void LogFileFailed ()
        {        
            Assert.IsTrue(false);
        }
    }

}
