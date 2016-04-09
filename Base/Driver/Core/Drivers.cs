using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace AutomationFrameWork.Driver.Core
{
    abstract public class Drivers
    {
        private static ThreadLocal<object> driverStored = new ThreadLocal<object>();
        private static ThreadLocal<ChromeOptions> chromeOption = new ThreadLocal<ChromeOptions>();
        private static ThreadLocal<DesiredCapabilities> desiredCapabilities = new ThreadLocal<DesiredCapabilities>();
        private static ThreadLocal<object> OptionStorage = new ThreadLocal<object>();
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
        abstract public void StartDriver();
        abstract public object DriverOption { get; }
        public static object DriverOptions
        {
            get
            {
                return OptionStorage.Value;
            }
            set
            {
                OptionStorage.Value = value;
            }
        }
    }
}
