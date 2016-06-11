using System;
using OpenQA.Selenium;
using AutomationFrameWork.Driver;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Appium;
using AutomationFrameWork.Exceptions;

namespace AutomationFrameWork.Driver
{
    public static class DriverFactory
    {      
     
        /// <summary>
        /// This method is use for
        /// return WebDriver ex: Chrome, Firefox, IE
        /// </summary>
        public static IWebDriver WebDriver
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
        public static PhantomJSDriver PhantomJSDriver
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
        public static AppiumDriver<AppiumWebElement> MobileDriver
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
        public static void CloseDriver ()
        {
            Drivers.CloseDrivers();
        }
        /// <summary>
        /// This method is use for
        /// start driver
        /// </summary>
        /// <param name="driverType"></param>
        public static void StartDriver (DriverType driverType, int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximazie = false)
        {           
            Drivers.StartDrivers(driverType,pageLoadTimeout,scriptTimeout,isMaximazie);
        }      

        public static void StartDriver (DriverType driverType, bool isMaximazie = false)
        {
            Drivers.StartDrivers(driverType, isMaximize: isMaximazie);
        }        

        public static void StartDriver (DriverType driverType, int pageLoadTimeout = 60)
        {           
            Drivers.StartDrivers(driverType, pageLoadTimeout:pageLoadTimeout);
        }

        public static void StartDriver (DriverType driverType, int pageLoadTimeout = 60, bool isMaximazie = false)
        {
            Drivers.StartDrivers(driverType, pageLoadTimeout: pageLoadTimeout, isMaximize: isMaximazie);
        }
        public static void StartDriver (DriverType driverType)
        {
            Drivers.StartDrivers(driverType);
        }
        /// <summary>
        /// This method is use for
        /// set driver option : Ex: ChromeOptions, InternetOptions...
        /// </summary>
        public static object DriverOption
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
        public static DesiredCapabilities DesiredCapabilities
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
        public static object DriverServices
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
        public static String RemoteUri
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