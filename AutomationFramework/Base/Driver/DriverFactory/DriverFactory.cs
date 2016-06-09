using System;
using OpenQA.Selenium;
using AutomationFrameWork.Driver.Core;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Appium;
using AutomationFrameWork.Exceptions;

namespace AutomationFrameWork.Driver
{
    public class DriverFactory
    {       
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
        public IWebDriver GetWebDriver // TODO review: should be method;  should pass parameter to indicate if user would like to start driver before getting it?
        {
            get
            {
                if (Drivers.DriverStorage == null)
                    throw new StepErrorException("Please call method DriverFactory.Instance.StartDriver(DriverType) for instance driver before can get");                          
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
                if (Drivers.DriverStorage == null)
                    throw new StepErrorException("Please call method DriverFactory.Instance.StartDriver(DriverType) for instance driver before can get");             
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
                if (Drivers.DriverStorage == null)
                    throw new StepErrorException("Please call method DriverFactory.Instance.StartDriver(DriverType) for instance driver before can get");              
                return (AppiumDriver<AppiumWebElement>)Drivers.DriverStorage;
            }
        }
        /// <summary>
        /// This method use for
        /// close driver
        /// </summary>
        public void CloseDriver ()
        {
            Drivers.CloseDrivers();
        }
        // TODO: duplicate code in overloads of StartDriver - should refactor to remain 1 only
        /// <summary>
        /// This method is use for
        /// start driver
        /// </summary>
        /// <param name="driverType"></param>
        public void StartDriver (DriverType driverType, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximazie = false)
        {           
            Drivers.StartDrivers(driverType,pageLoadTimeout,scriptTimeout,isMaximazie);
        }      

        public void StartDriver (DriverType driverType, bool isMaximazie = false)
        {
            Drivers.StartDrivers(driverType, isMaximize: isMaximazie);
        }        

        public void StartDriver (DriverType driverType, int pageLoadTimeout = 60)
        {           
            Drivers.StartDrivers(driverType, pageLoadTimeout:pageLoadTimeout);
        }

        public void StartDriver (DriverType driverType, int pageLoadTimeout = 60, bool isMaximazie = false)
        {
            Drivers.StartDrivers(driverType, pageLoadTimeout: pageLoadTimeout, isMaximize: isMaximazie);
        }
        public void StartDriver (DriverType driverType)
        {
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
        public object DriverServices
        {
            get
            {
                return Drivers.DriverService;
            }
            set
            {
                Drivers.DriverService = value;
            }
        }
        /// <summary>
        /// This method is use
        /// for set up URI in Remote Driver, Mobile Driver 
        /// </summary>
        public String RemoteUri
        {
            get
            {               
                return Drivers.RemoteUriCore;
            }
            set
            {
                Drivers.RemoteUriCore = value;
            }
        }
    }
}