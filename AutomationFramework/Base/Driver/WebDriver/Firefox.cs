using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationFrameWork.Driver.Core
{
    class Firefox : Drivers
    {
        private static readonly Firefox _instance = new Firefox();
        static Firefox ()
        {
        }
        private Firefox ()
        {

        }

        public static Firefox Instance
        {
            get
            {
                return _instance;
            }
        }
        protected override object StartDriver (int pageLoadTimeout = 60, int scriptTimeout = 60, bool isMaximize = false)
        {
            IWebDriver driver = new FirefoxDriver(Firefox.Instance.DesiredCapabilities);
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(pageLoadTimeout));
            driver.Manage().Timeouts().SetScriptTimeout(System.TimeSpan.FromSeconds(scriptTimeout));
            if (isMaximize)
                driver.Manage().Window.Maximize();           
            return driver;
        }
        /// <summary>
        /// Not implement this method for firefox
        /// </summary>
        protected override object DriverOption
        {
            get
            {
                return null;
            }
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