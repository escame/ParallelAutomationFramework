using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

namespace AutomationFrameWork.Driver.Core
{
    class iOS : Drivers
    {
        protected override object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            IOSDriver<AppiumWebElement> driver = new IOSDriver<AppiumWebElement>(new Uri(Drivers.RemoteUriCore), Drivers.DesiredCapabilitiesCore);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            return driver;
        }
    }
}

