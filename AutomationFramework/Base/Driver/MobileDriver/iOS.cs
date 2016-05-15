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
        private static int _port = 0;
        private static string _address = string.Empty;
        private static int _timeConnect = 60;
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
        private static void GetInfo()
        {
            Dictionary<string, string> info = (Dictionary<string, string>)Drivers.RemoteInfo;
            if (info == null)
                throw new ArgumentException("Please add Appium Server information for connect to server in DriverFactory.Instance.RemoteInfo(String address,int port)");
            else
            {
                _address = info["address"];
                _port = Int32.Parse(info["port"]);
                _timeConnect = Int32.Parse(info["time"]) <= 60 || Int32.Parse(info["time"]) >= 10 ? Int32.Parse(info["time"]) : _timeConnect;
            }
        }
        protected override void StartDriver ()
        {
            GetInfo();
            TimeSpan _maxIdle = TimeSpan.FromSeconds(_timeConnect);
            DateTime _startTime = DateTime.UtcNow;
            while (_startTime.Add(_maxIdle) > DateTime.UtcNow)
            {
                //loop for make sure appium running
            }
            Drivers.DriverStorage = new IOSDriver<AppiumWebElement>(new Uri("http://" + _address + ":" + _port + "/wd/hub"), iOS.Instance.DesiredCapabilities);
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

