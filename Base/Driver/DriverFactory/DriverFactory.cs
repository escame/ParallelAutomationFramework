using OpenQA.Selenium;
using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System;
using System.Threading;

namespace AutomationFrameWork.Driver
{
    class DriverFactory : Drivers
    {
        private int _pageLoadTimeout;
        private int _scriptTimeout;
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
                IWebDriver _Driver = (IWebDriver)Drivers.DriverStorage;
                _Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(_pageLoadTimeout));
                _Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(_scriptTimeout));
                return _Driver;
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
                PhantomJSDriver _Driver = (PhantomJSDriver)Drivers.DriverStorage;
                _Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(_pageLoadTimeout));
                _Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(_scriptTimeout));
                return _Driver;
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
                AppiumDriver<AppiumWebElement> _Driver = (AppiumDriver<AppiumWebElement>)Drivers.DriverStorage;
                _Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(_pageLoadTimeout));
                _Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(_scriptTimeout));
                return _Driver;
            }
        }
        /// <summary>
        /// This method use for
        /// close driver
        /// </summary>
        public void CloseDriver ()
        {
            Drivers.CloseDrivers();
        }/// <summary>
         /// This method is use for
         /// start driver
         /// </summary>
         /// <param name="driverType"></param>
        public void StartDriver (DriverType driverType,int pageLoadTimeout=60, int scriptTimeout=60)
        {
            _pageLoadTimeout = pageLoadTimeout;
            _scriptTimeout = scriptTimeout;
            Drivers.StartDrivers(driverType);
        }
        /// <summary>
        /// This method is use for
        /// set driver option : Ex: ChromeOptions, InternetOptions...
        /// </summary>
        public new object DriverOptions
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
        public void RemoteInformation (string address, int port,int timeConnectServer=60)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("address", address);
            info.Add("port", port.ToString());
            info.Add("time", timeConnectServer.ToString());
            Drivers.RemoteInfo = info;
        }
        /// <summary>
        /// This method is use 
        /// for set up DesiredCapabilities in Remote Driver, Mobile Driver
        /// </summary>
        public new DesiredCapabilities DesiredCapabilities
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