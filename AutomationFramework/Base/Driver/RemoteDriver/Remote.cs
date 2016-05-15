using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    class Remote : Drivers
    {
        private static readonly Remote _instance = new Remote();
        private static int _port = 0;
        private static string _address = string.Empty;
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
        private static void GetInfo ()
        {
            Dictionary<string, string> info = (Dictionary<string, string>)Drivers.RemoteInfo;
            if (info == null)
                throw new ArgumentException("Please add RemoteDriver information for connect to server in DriverFactory.Instance.RemoteInfo(String address,int port)");
            else
            {
                _address = info["address"];
                _port = Int32.Parse(info["port"]);
            }
        }
        protected override void StartDriver ()
        {
            GetInfo();
            Drivers.DriverStorage = new RemoteWebDriver(new Uri("http://" + _address + ":" + _port + "/wd/hub"), Remote.Instance.DesiredCapabilities);
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

