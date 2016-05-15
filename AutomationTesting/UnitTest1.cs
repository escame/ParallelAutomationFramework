using System;
using NUnit.Framework;
using AutomationFrameWork.Reporter.ReportAttributes;
using AutomationFrameWork.Driver;
using AutomationFrameWork.Driver.Core;
using AutomationFrameWork.Utils;
namespace AutomationTesting
{
    [HTML]
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMapping ()
        {
            DriverFactory.Instance.StartDriver(DriverType.Chrome);
            DriverFactory.Instance.GetWebDriver.Url = "http://www.google.com";
            DriverFactory.Instance.CloseDriver();                        
        }
    }
}
