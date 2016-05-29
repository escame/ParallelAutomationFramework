using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationFrameWork.Base.TestEventListener;
using System.Runtime.CompilerServices;
using NUnit.Engine;
using AutomationFrameWork.Driver;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using AutomationFrameWork.Utils;
using AutomationFrameWork.ActionsKeys;

namespace AutomationTesting
{
   
   
    public class TestITestListener 
    {
        [Category("Capture Element Image")]
        [Test]
        public void Event ()
        {
            ChromeOptions op = new ChromeOptions();
            op.EnableMobileEmulation("Apple iPhone 4");
            //DriverFactory.Instance.DriverOption = op;
            DriverFactory.Instance.StartDriver(DriverType.Chrome,true);
            IWebDriver driver = DriverFactory.Instance.GetWebDriver;
            driver.Url = "https://www.whatismybrowser.com/";
            IWebElement el = driver.FindElement(By.XPath("//*[@id='holder']//*[@class='detection-primary content-block']"));
            WebKeywords.Instance.GetScreenShot();
            Utilities.Instance.GetWebElementBaseImage(el,formatType: System.Drawing.Imaging.ImageFormat.Jpeg);
            driver.Dispose();
            DriverFactory.Instance.CloseDriver();
        }
    }
}
