using OpenQA.Selenium;
using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System;
using System.Threading;
using AutomationFrameWork.Exceptions;

namespace AutomationFrameWork.Driver
{
    public class DriverFactory
    {
        private int _pageLoadTimeout;
        private int _scriptTimeout;
        private bool _isMaximize;
        private static readonly DriverFactory _instance = new DriverFactory();
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
                return _instance;
            }
        }
        /// <summary>
        /// This method is use for
        /// return WebDriver ex: Chrome, Firefox, IE
        /// </summary>
        public IWebDriver GetWebDriver
        {
            get
            {
                if (Drivers.DriverStorage == null)
                    throw new StepErrorException("Please call method DriverFactory.Instance.StartDriver(DriverType) for instance driver before can get");
                IWebDriver driver = (IWebDriver)Drivers.DriverStorage;
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(_pageLoadTimeout));
                driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(_scriptTimeout));
                if (_isMaximize)
                    driver.Manage().Window.Maximize();
                return driver;
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
                if (Drivers.DriverStorage == null)
                    throw new StepErrorException("Please call method DriverFactory.Instance.StartDriver(DriverType) for instance driver before can get");
                PhantomJSDriver driver = (PhantomJSDriver)Drivers.DriverStorage;
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(_pageLoadTimeout));
                driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(_scriptTimeout));
                return driver;
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
                if (Drivers.DriverStorage == null)
                    throw new StepErrorException("Please call method DriverFactory.Instance.StartDriver(DriverType) for instance driver before can get");
                AppiumDriver<AppiumWebElement> driver = (AppiumDriver<AppiumWebElement>)Drivers.DriverStorage;
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(_pageLoadTimeout));
                driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(_scriptTimeout));
                return driver;
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
        public void StartDriver (DriverType driverType, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximazie = false)
        {
            _pageLoadTimeout = pageLoadTimeout;
            _scriptTimeout = scriptTimeout;
            _isMaximize = isMaximazie;
            Drivers.StartDrivers(driverType);
        }
        /// <summary>
        /// This method is use for
        /// set driver option : Ex: ChromeOptions, InternetOptions...
        /// </summary>
        public object DriverOption
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
        /// This method is use 
        /// for set up DesiredCapabilities in Remote Driver, Mobile Driver
        /// </summary>
        public DesiredCapabilities DesiredCapabilities
        {
            get
            {
                return Drivers.DesiredCapabilitiesCore;
            }
            set
            {
                Drivers.DesiredCapabilitiesCore = value;
            }
        }
        public String RemoteUri
        {
            get
            {
                if (Drivers.RemoteUriCore == null)
                    throw new StepErrorException("Please set Uri for Remote Server");
                return Drivers.RemoteUriCore;
            }
            set
            {
                Drivers.RemoteUriCore = value;
            }
        }
    }
}