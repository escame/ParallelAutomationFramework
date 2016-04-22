using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    public class Remote : Drivers
    {
        private static readonly Remote instance = new Remote();
        public static int port = 0;
        public static string address = string.Empty;
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
                return instance;
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
                throw new ArgumentException("Please add RemoteDriver information for connect to server in DriverFactory.Instance.RemoteInfo(String address,int port)");
            else
            {
                address = info["address"];
                port = Int32.Parse(info["port"]);
            }
        }
        protected override void StartDriver ()
        {
            GetInfo();
            Drivers.DriverStorage = new RemoteWebDriver(new Uri("http://" + address + ":" + port + "/wd/hub"), Remote.Instance.DesiredCapabilities);
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

