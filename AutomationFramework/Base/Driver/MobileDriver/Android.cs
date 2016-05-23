using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    class Android : Drivers
    {
        private static readonly Android _instance = new Android();        
        static Android ()
        {
        }
        private Android ()
        {
        }
        public static Android Instance
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
            Drivers.DriverStorage = new AndroidDriver<AppiumWebElement>(new Uri(Drivers.RemoteUriCore), Android.Instance.DesiredCapabilities);
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
