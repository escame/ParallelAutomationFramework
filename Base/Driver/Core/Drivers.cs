using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;

namespace AutomationFrameWork.Driver.Core
{
    abstract public class Drivers
    {
        static readonly object syncRoot = new Object();
        static ThreadLocal<object> driverStored = new ThreadLocal<object>();
        static ThreadLocal<DesiredCapabilities> desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
        static ThreadLocal<object> optionStorage = new ThreadLocal<object>();        
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        protected static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)driverStored.Value;
            driver.Quit();
            driver.Dispose();
            driverStored.Value = null;
        }
        /// <summary>
        /// This method is use 
        /// for return object with can be MobileDriver or WebDriver
        /// </summary>
        /// <returns></returns>
        protected static object DriverStorage
        {
            get
            {
                return driverStored.Value;
            }
            set
            {
                driverStored.Value = value;
            }
        }
        /// <summary>
        /// This method is use 
        /// for setting DesiredCapabilities for Remote Driver, Firefox Driver, PhantomJs Driver
        /// </summary>
        protected static DesiredCapabilities DesiredCapabilities
        {
            get
            {
                if (Drivers.desiredCapabilities.Value == null)
                    Drivers.desiredCapabilities.Value = new DesiredCapabilities();
                return Drivers.desiredCapabilities.Value;
            }
            set
            {
                Drivers.desiredCapabilities.Value = value;
            }
        }
        /// <summary>
        /// This method is use
        /// for return DriverOption like ChromeOption, InternetExplorerOption
        /// </summary>
        protected static object DriverOptions
        {
            get
            {
                return optionStorage.Value;
            }
            set
            {
                optionStorage.Value = value;
            }
        }        
        virtual public void StartDriver() { }
        virtual protected object DriverOption
        {
            get;
        }

    }
}
