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

    public class TestNlog
    {
        [Test]
        public void LogFile()
        {
            ReportManager.logger.Info("This info log");
            ReportManager.logger.Error("This error log");
        }
    }

}
