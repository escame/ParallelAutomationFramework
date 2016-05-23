using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    class Remote : Drivers
    {
        private static readonly Remote _instance = new Remote();     
        static Remote ()
        {
        }
        private Remote ()
        {
        }
        public static Remote Instance
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
            Drivers.DriverStorage = new RemoteWebDriver(new Uri(Drivers.RemoteUriCore), Remote.Instance.DesiredCapabilities);
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

