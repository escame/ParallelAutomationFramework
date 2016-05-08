using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

namespace AutomationFrameWork.Driver.Core
{
    public class iOS : Drivers
    {
        private static readonly iOS _instance = new iOS();
        private static int _port = 0;
        private static string _address = string.Empty;
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
            Drivers.DriverStorage = new IOSDriver<AppiumWebElement>(new Uri("http://" + _address + ":" + _port + "/wd/hub"), iOS.Instance.DesiredCapabilities);
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

