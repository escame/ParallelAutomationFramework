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
        protected override void StartDriver ()
        {           
            Drivers.DriverStorage = new IOSDriver<AppiumWebElement>(new Uri(Drivers.RemoteUriCore), iOS.Instance.DesiredCapabilities);
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

