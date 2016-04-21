using AutomationFrameWork.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System;
using System.Threading;

namespace AutomationFrameWork.Driver
{
    public class DriverFactory 
    {
        //private static readonly DriverFactory instance = new DriverFactory();
        static DriverFactory ()
        {
        }
        private DriverFactory ()
        {
        }
        public static DriverFactory Instance
        {
            get
            {
                return DriverFactory.DriverFactoryInstance.Value;
            }
        }
        static ThreadLocal<DriverFactory> DriverFactoryInstance = new ThreadLocal<DriverFactory>(() =>
        {

            return new DriverFactory();

        });
        /// <summary>
        /// This method is use for
        /// return WebDriver ex: Chrome, Firefox, IE
        /// </summary>
        public IWebDriver GetWebDriver
        {
            get
            {
                return (IWebDriver)Drivers.DriverStorage;
            }
        }
        /// <summary>
        /// This method is use for
        /// get phantomjs driver, use for headless browser testing
        /// </summary>
        public PhantomJSDriver GetPhantomJSDriver
        {
            get
            {
                return (PhantomJSDriver)Drivers.DriverStorage;
            }
        }
        /// <summary>
        /// This method is use for
        /// get mobile driver, it include android and ios 
        /// </summary>
        public AppiumDriver<AppiumWebElement> GetMobileDriver
        {
            get
            {
                return (AppiumDriver<AppiumWebElement>)Drivers.DriverStorage;
            }
        }
        /// <summary>
        /// This method use for
        /// close driver
        /// </summary>
        public void CloseDriver ()
        {
            Drivers.CloseDriver();
        }/// <summary>
         /// This method is use for
         /// start driver
         /// </summary>
         /// <param name="driverType"></param>
        public void StartDriver (DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Chrome:
                    Chrome.Instance.StartDriver();
                    break;
                case DriverType.EmulationiPad:
                    EmulationiPad.Instance.StartDriver();
                    break;
                case DriverType.EmulationiPhone6:
                    EmulationiPhone6.Instance.StartDriver();
                    break;
                case DriverType.EmulationiPhone5:
                    EmulationiPhone5.Instance.StartDriver();
                    break;
                case DriverType.EmulationiPhone4:
                    EmulationiPhone4.Instance.StartDriver();
                    break;
                case DriverType.InternetExplore:
                    InternetExplore.Instance.StartDriver();
                    break;
                case DriverType.Firefox:
                    Firefox.Instance.StartDriver();
                    break;
                case DriverType.PhantomJS:
                    PhantomJS.Instance.StartDriver();
                    break;
                case DriverType.Android:
                    Android.Instance.StartDriver();
                    break;
                case DriverType.iOS:
                    iOS.Instance.StartDriver();
                    break;

            }
        }       
        /// <summary>
        /// This method is use for
        /// set driver option : Ex: ChromeOptions, InternetOptions...
        /// </summary>
        public object DriverOptions
        {
            get
            {
                return Drivers.DriverOptions;
            }
            set
            {
                Drivers.DriverOptions = value;
            }
        }
        /// <summary>
        /// Add information to connect appium server to DriverOption        
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void AppiumInfo (string address, int port)
        {           
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("address", address);
            info.Add("port", port.ToString());       
            DriverFactory.Instance.DriverOptions = info;
        }
        /// <summary>
        /// This method is use 
        /// for set up DesiredCapabilities in Remote Driver, Mobile Driver
        /// </summary>
        public DesiredCapabilities DesiredCapabilities
        {
            get
            {
                return Drivers.DesiredCapabilities;
            }
            set
            {
                Drivers.DesiredCapabilities = value;
            }
        }
    }
}