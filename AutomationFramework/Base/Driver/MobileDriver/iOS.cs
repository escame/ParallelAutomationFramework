using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

namespace AutomationFrameWork.Driver.Core
{
    class iOS : Drivers
    {
        private static readonly iOS _instance = new iOS();     
        static iOS ()
        {

        }
        private iOS ()
        {
        }
        public static iOS Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override object DriverOption
        {
            get
            {
                return 1;
            }
        }        
        protected override object  StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {           
            IOSDriver<AppiumWebElement> driver = new IOSDriver<AppiumWebElement>(new Uri(Drivers.RemoteUriCore), iOS.Instance.DesiredCapabilities);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            return driver;
        }

        private DesiredCapabilities DesiredCapabilities
        {
            get
            {
                return Drivers.DesiredCapabilitiesCore;
            }
        }
    }
}

