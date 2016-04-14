using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace AutomationFrameWork.Driver.Core
{
    abstract public class Drivers
    {
        private static ThreadLocal<object> driverStored = new ThreadLocal<object>();
        private static ThreadLocal<ChromeOptions> chromeOption = new ThreadLocal<ChromeOptions>();
        private static ThreadLocal<DesiredCapabilities> desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
        private static ThreadLocal<object> optionStorage = new ThreadLocal<object>();        
        private static ThreadLocal<List<int>> portStorage = new ThreadLocal<List<int>>();
        public static volatile List<int> FreePort = new List<int>();
        public static volatile List<int> UsedPort=new List<int>();
        /// <summary>
        /// This method use for close driver 
        /// </summary>
        public static void CloseDriver()
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
        public static object DriverStorage
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
        /// for set chrome option in Chrome Driver
        /// </summary>
        public static ChromeOptions ChromeOptions
        {
            get
            {
                if (Drivers.chromeOption.Value == null)
                    Drivers.chromeOption.Value = new ChromeOptions();
                return Drivers.chromeOption.Value;
            }
            set
            {
                Drivers.chromeOption.Value = value;
            }
        }
        /// <summary>
        /// This method is use 
        /// for setting DesiredCapabilities for Remote Driver, Firefox Driver, PhantomJs Driver
        /// </summary>
        public static DesiredCapabilities DesiredCapabilities
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
        public static object DriverOptions
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
        /*
        /// <summary>
        /// This method is use 
        /// for return FreePort for run appium
        /// </summary>
        public static List<int> FreePort
        {
            get
            {
                return freePort.Value;
            }
            set
            {
                freePort.Value = value;
            }
        }
        */
        /// <summary>
        /// This method is use 
        /// for storeage port in use for run appium
        /// </summary>
        public static List<int> PortStorage
        {
            get
            {
                return portStorage.Value;
            }
            set
            {
                portStorage.Value = value;
            }
        }
        abstract public void StartDriver();
        abstract public object DriverOption { get; }
        
    }
}
