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
        private static int _port = 0;
        private static string _address = string.Empty;
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
        private static void GetInfo ()
        {
            Dictionary<string, string> info = (Dictionary<string, string>)Drivers.DriverOptions;
            if (info == null)
                throw new ArgumentException("Please add Appium Server information for connect to server in DriverFactory.Instance.RemoteInfo(String address,int port)");
            else
            {
                _address = info["address"];
                _port = Int32.Parse(info["port"]);
            }
        }
        protected override void StartDriver ()
        {
            GetInfo();
            Drivers.DriverStorage = new AndroidDriver<AppiumWebElement>(new Uri("http://" + _address + ":" + _port + "/wd/hub"), Android.Instance.DesiredCapabilities);
        }

        private new DesiredCapabilities DesiredCapabilities
        {
            get
            {
                return Drivers.DesiredCapabilities;
            }
        }
    }
}
