using AutomationFrameWork.Driver.Core;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    public class Android : Drivers
    {
        private static readonly Android instance = new Android();     
        public static int port = 0;
        public static string address = string.Empty;
        static Android()
        {

        }
        private Android()
        {
        }
        public static Android Instance
        {
            get
            {
                return instance;
            }
        }
        /*
        ThreadLocal<AndroidDriver<AppiumWebElement>> driver = new ThreadLocal<AndroidDriver<AppiumWebElement>>(() =>
        {
            GetInfo();
            android = new AndroidDriver<AppiumWebElement>(new Uri("http://" + address + ":" + port + "/wd/hub"), Android.Instance.DesiredCapabilities);
            return android;

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
                port=Int32.Parse(info["port"]);
            }
        }
        public override void StartDriver()
        {
            GetInfo();
            Drivers.DriverStorage = new AndroidDriver<AppiumWebElement>(new Uri("http://" + address + ":" + port + "/wd/hub"), Android.Instance.DesiredCapabilities);
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
