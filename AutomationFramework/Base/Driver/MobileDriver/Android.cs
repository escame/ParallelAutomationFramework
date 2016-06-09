using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    class Android : Drivers
    {
        protected override object StartDriver(int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            AndroidDriver<AppiumWebElement> driver = new AndroidDriver<AppiumWebElement>(new Uri(Drivers.RemoteUriCore), Drivers.DesiredCapabilitiesCore);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            return driver;
        }
    }
}
