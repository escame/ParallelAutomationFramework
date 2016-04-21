using AutomationFrameWork.Driver.Core;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace AutomationFrameWork.Driver.Core
{
    public class iOS : Drivers
    {
        private static readonly iOS instance = new iOS();   
        public static int port = 0;
        public static string address = string.Empty;
        static iOS()
        {

        }
        private iOS()
        {
        }
        public static iOS Instance
        {
            get
            {
                return instance;
            }
        }
        /*
        ThreadLocal<IOSDriver<AppiumWebElement>> driver = new ThreadLocal<IOSDriver<AppiumWebElement>>(() =>
        {
            GetInfo();
            iOSDriver = new IOSDriver<AppiumWebElement>(new Uri("http://" + address + ":" + port + "/wd/hub"), iOS.Instance.DesiredCapabilities);
            return iOSDriver;

        });
        */
        protected override object DriverOption
        {
            get
            {
                return 1;
            }
        }
        private static void GetInfo()
        {
            Dictionary<string, string> info = (Dictionary<string, string>)Drivers.DriverOptions;
            if (info == null)
                throw new ArgumentException("Please add appium information for connect to server in DriverFactory.Instance.AppiumInfo(String address,int port)");
            else
            {
                address = info["address"];
                port = Int32.Parse(info["port"]);
            }
        }
        public override void StartDriver()
        {
            GetInfo();
            Drivers.DriverStorage = new IOSDriver<AppiumWebElement>(new Uri("http://" + address + ":" + port + "/wd/hub"), iOS.Instance.DesiredCapabilities);
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

